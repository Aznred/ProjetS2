import time
import random
import string
from functools import wraps
import matplotlib.pyplot as plt
from base64 import b64encode
import io
import numpy as np
from builtins import TypeError


def timer(f):
    @wraps(f)
    def wrapper(num, *args, **kwargs):
        runtime = time.time()
        ret = f(num, *args, **kwargs)
        return time.time() - runtime, ret
    return wrapper


def plot_to_str(plot):
    buf = io.BytesIO()
    plot.savefig(fname=buf, format='png')
    buf.seek(0)
    byte_content = buf.read()
    base64_bytes = b64encode(byte_content)
    return base64_bytes.decode('utf-8')


def rand_str(num):
    return ''.join([random.choice(string.ascii_letters + string.digits) for n in range(num)])


class HpoExpRes:
    def __init__(self, result, plot=None, model=None):
        self.result = None
        self.set_result(result)

        if plot is None:
            self.plot = ''
        else:
            self.set_plot(plot)

        self.model = model

    def set_result(self, result):
        result_type = type(result)
        if str(result_type).startswith(str(type(np.float))):
            self.result = np.asscalar(result)
        elif result_type is float:
            self.result = result
        else:
            raise TypeError('Expected float or numpy.float. received ' + str(result_type))

    def set_model(self, model):
        self.model = model

    def set_plot(self, plot: plt):
        self.plot = plot_to_str(plot)


class TrainValid:

    def __init__(self, train_x, train_y, valid_x, valid_y):
        self.train_x = train_x
        self.train_y = train_y
        self.valid_x = valid_x
        self.valid_y = valid_y
