import os
import ast
import atexit
import random
import string
import requests
import json
import jsonpickle
import logging
from io import BytesIO
from .finder import get_needed_source
import tarfile

from .fedutils import plot_to_str

import urllib3
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)


# Modify federer host to be with protocol
def _protocolize(url):
    protocol = "http://"
    if ast.literal_eval(os.getenv('IS_SECURE', 'False')):
        protocol = "https://"
    return protocol + url


FEDERER_HOST = _protocolize(os.getenv("FEDERER_HOST", "federer.np.idf.cts"))


class MLAgent:
    """
    Federer class. Train and Serve - just like Roger Federer
    """

    def __init__(self, project_name):
        """
        creates the variable associated with this class

        :type project_name: string
        :param project_id: the id of the project
        """
        self._data = dict()
        self._data['experimentId'] = ''.join([random.choice(string.ascii_letters + string.digits) for n in range(8)])
        self._data['project_id'] = project_name
        self._data['metrics'] = {}
        self._data['results'] = 0
        self._data['plots'] = []
        self._data['author'] = os.getenv('JUPYTERHUB_USER', 'John Doe')
        self.bucket_name = 'federer'
        self.logger = logging.getLogger("Federer")
        self.was_committed = False
        atexit.register(self._auto_commit)

    def save(self, k, v):
        """
        save parameters from your experiment (name and value)

        :type k: string
        :param k: metrics key
        :type v: your paramer type
        :param v: metrics value
        """
        self._data['metrics'][k] = v

    def results(self, result):
        """
        save the result of your experiment

        :type result: your result type
        :param result: the result to be stored
        """
        self._data['results'] = result

    def model(self, model):
        """
        save all the parameters of a given model

        :type model: dictionary
        :param model: the model
        """
        attributes = model.__dict__.items()
        if attributes:
            for field, value in attributes:
                self._data['metrics'][field] = value

    def _auto_commit(self):
        if not self.was_committed:
            self.commit()

    def commit(self):
        """
        creates the experiment and returns the response from the server
        """
        if len(self._data['metrics']) == 0:
            return

        request = requests.post(FEDERER_HOST + '/api/createExperiment', data=json.dumps(self._data), verify=False)
        # Clear the data after commit
        self._data['metrics'] = {}
        self._data['results'] = 0
        self._data['plots'] = []
        self.was_committed = True
        return request

    def plot(self, plot):
        """
        saves a plot in the experiment history

        :type plot: Object
        :param plot: The matplotlib/seaborn plot object
        """
        self._data['plots'].append(plot_to_str(plot))
        plot.show()

    def deploy(self, framework, model_path, preprocessing_func_name, tag, **kwargs):
        """
        deploy a model and return the request from the server

        :type framework: string
        :param framework: the framework of the model
        :type model_path: string
        :param model_path: path of your model file
        :type preprocessing_func_name: string
        :param preprocessing_func_name: name of your preprocessing function
        :type tag: string
        :param tag: tag of the deployment
        :type kwargs: dictionary
        :param kwargs: 2 boolean options: is_test and to_route \n
                       is_test: is this deployment test or prod \n
                       to_route: make a route (URL) to your deployment?
        """
        if framework is None or model_path is None:
            self.logger.error("Framework / model path not specified")
            return
        else:
            """
            project_id = self._data['project_id']
            self._data = dict()
            self._data['project_id'] = project_id
            """
            self._data['tag'] = tag
            self._data['module_code'] = get_needed_source(preprocessing_func_name)
            self._data['function_name'] = preprocessing_func_name
            self._data['framework'] = framework
            self._data['model_path'] = model_path
            self._data['is_test'] = kwargs.get('is_test')
            self._data['to_route'] = kwargs.get('to_route')
            self._data['gpu_units'] = kwargs.get('gpu_units', 0)
            self._data['cores'] = kwargs.get('cores', 1)
            self._data['ram'] = kwargs.get('ram', 0.2)

            request = requests.post(FEDERER_HOST + '/api/deployModel', data=json.dumps(self._data), verify=False)
            return request

    def deploy_hpo(self, framework, objective_func_name, space, gpu_units=0, workers_num=4, eval_num=100,
                   init_func_name=None, algorithm='tpe', cores=1, ram_gigs=0.2,
                   namespace='federer', git_repo='', addon_envs=dict()):
        """
        Deploys HPO Task 

        :type framework: string
        :param framework: the framework of the model
        :type objective_func_name: string
        :param objective_func_name: name of your objective function
        :type space: federer.hpo.Apply
        :param space: search space of the given arguments
        :type gpu_units: int
        :param gpu_units: indicates the amount of gpu units
        :type workers_num: int
        :param workers_num: the amounts of workers on the openshift
        :type eval_num: int
        :param eval_num: indicates the amounts of evaluations to run
        :type init_func_name: string
        :param init_func_name: The function name which will run in the initialization of the evaluation runner
        :param algorithm:
        :param cores: cores amount
        :param ram_gigs: ram gigs amount
        :param namespace: namespace name
        :param git_repo: git repo to pull
        :param addon_envs: environmental variables to add to pod
        :return: returns request result
        """
        self._data['function_code'] = get_needed_source(objective_func_name)
        self._data['function_name'] = objective_func_name
        self._data['namespace'] = namespace
        self._data['framework'] = framework
        self._data['gpu_units'] = gpu_units
        self._data['cores'] = cores
        self._data['ram'] = ram_gigs
        self._data['algo'] = algorithm
        self._data['is_gen'] = False
        self._data['workers_num'] = workers_num
        if git_repo:
            self._data['os_env'] = dict(addon_envs)
            self._data['os_env']['OBJECTIVE_CODE_GIT_REPO'] = git_repo
        if init_func_name is not None:
            self._data['function_code'] = '%s\n%s' % (get_needed_source(init_func_name, True),
                                                      self._data['function_code'])
        self._data['init_code'] = ''
        self._data['eval_num'] = eval_num
        self._data['space'] = jsonpickle.encode(space).replace('mlagent', 'py.hyperopt')
        request = requests.post(FEDERER_HOST + '/api/deployHpo', data=json.dumps(self._data), verify=False)
        return request


def deploy_sam(local_project_dir, **kwargs):
    project_dir_name = local_project_dir.split('/')[-1]
    tarred_file = BytesIO()

    tt = tarfile.open(fileobj=tarred_file, mode='w:gz')
    tt.add(local_project_dir, arcname=project_dir_name)
    tt.close()

    kwargs['tar_name'] = project_dir_name
    kwargs['tar_file_bytes'] = tarred_file.getvalue()

    with open(os.path.expanduser('~') + '\\.federer_login_settings.json', 'r') as settings:
        cookies = json.loads(settings.read())

    request = requests.post(_protocolize(cookies['index']) + '/sam/deploySam',
                            data=jsonpickle.dumps(dict(kwargs), unpicklable=False), verify=False, cookies=cookies)
    return request


def login(**kwargs):
    with open(os.path.expanduser('~') + '\\.federer_login_settings.json', 'w') as settings:
        settings.write(json.dumps(kwargs))

'''
    def upload(self, file_key, file_data):
        """
        upload a file to the object storage

        :type file_key: string
        :param file_key: key of the object to be saved in the object storage
        :type file_data: string
        :param file_data: data of the file to uploaded
        """
        self.swift_connection.put_object(self.bucket_name,
                                         self._data['experimentId'] + '/' + file_key,
                                         contents=file_data)

    def download(self, file_key, file_name):
        """
        download an object

        :type file_key: string
        :param file_key: key of the object in the object storage
        :type file_name: string
        :param file_name: name of the file to be downloaded
        """
        if Path(file_name).exists():
            self.logger.warning("File " + file_name + " already exists!")
        else:
            with open(file_name, 'wb') as file:
                object_contents = self.swift_connection.get_object(self.bucket_name, file_key)[1]
                file.write(object_contents)
'''
