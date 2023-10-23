# coding: utf-8

# Copyright (c) IPython Development Team.
# Distributed under the terms of the Modified BSD License.

from __future__ import unicode_literals
from __future__ import print_function

import sys
import os
import json
from optparse import OptionParser

from federer_pip import federerpip

def main():
    usage = "Usage: federer [OPTIONS] arg"
    parser = OptionParser(usage)

    # sam
    parser.add_option("-n", "--project_name", dest="project_name", default="default")
    parser.add_option("-c", "--cores", dest="cores", default="1")
    parser.add_option("-r", "--ram", dest="ram", default="0.2")
    parser.add_option("-g", "--gpu", dest="gpu", default="0")
    parser.add_option("-p", "--port", dest="port", default="8000")

    # login
    parser.add_option("-u", "--user", dest="user")
    parser.add_option("-t", "--token", dest="token")
    parser.add_option("-i", "--index", dest="index")

    (options, args) = parser.parse_args()

    if args[0] == "sam":
        return federerpip.deploy_sam(os.getcwd().replace('\\', '/'), project_name=options.project_name,
                                     cores=options.cores, gpu_units=options.gpu, ram=options.ram)
    elif args[0] == "login":
        return federerpip.login(index=options.index, user=options.user, OAUTH_TOKEN=options.token)

    return 1


if __name__ == "__main__":
    sys.exit(main())
