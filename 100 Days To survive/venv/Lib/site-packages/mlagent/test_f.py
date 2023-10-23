import os
from federer_pip import Federer
import unittest

os.environ["FEDERER_HOST"] = "https://federer.np.idf.cts"


def preprocess(request):
    return "A string"


class TestF(unittest.TestCase):

    def setUp(self):
        self.federer_class = Federer("somename")

    def test_deploy(self):
        resp = self.federer_class.deploy(framework="torch", model_path="FaceAlignment.model",
               preprocessing_func_name="preprocess",
               tag="or3")
        self.assertEqual(resp.status_code, 200, "Something wrong when deleting deployment - empty?")


if __name__ == 'main':
    unittest.main()

