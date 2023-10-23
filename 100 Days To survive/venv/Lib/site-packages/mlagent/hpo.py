from __future__ import absolute_import
from functools import wraps
from .pyll.base import Literal
from .pyll import scope
from past.builtins import basestring
__author__ = 's8345579'


def validate_label(f):
    @wraps(f)
    def wrapper(label, *args, **kwargs):
        is_real_string = isinstance(label, basestring)
        is_literal_string = (isinstance(label, Literal) and
                             isinstance(label.obj, basestring))
        if not is_real_string and not is_literal_string:
            raise TypeError('require string label')
        return f(label, *args, **kwargs)
    return wrapper


@scope.define
def hyperopt_param(label, obj):
    """ A graph node primarily for annotating - VectorizeHelper looks out
    for these guys, and optimizes subgraphs of the form:

        hyperopt_param(<stochastic_expression>(...))

    """
    return obj


class HPO:

    @validate_label
    def choice(label, options):
        ch = scope.hyperopt_param(label,
                                  scope.randint(len(options)))
        return scope.switch(ch, *options)

    @validate_label
    def randint(label, *args, **kwargs):
        return scope.hyperopt_param(label,
                                    scope.randint(*args, **kwargs))

    @validate_label
    def pchoice(label, p_options):
        """
        label: string
        p_options: list of (probability, option) pairs
        """
        p, options = list(zip(*p_options))
        n_options = len(options)
        ch = scope.hyperopt_param(label,
                                  scope.categorical(
                                      p,
                                      upper=n_options))
        return scope.switch(ch, *options)

    @validate_label
    def uniform(label, *args, **kwargs):
        return scope.float(
            scope.hyperopt_param(label,
                                 scope.uniform(*args, **kwargs)))


    @validate_label
    def quniform(label, *args, **kwargs):
        return scope.float(
            scope.hyperopt_param(label,
                                 scope.quniform(*args, **kwargs)))


    @validate_label
    def loguniform(label, *args, **kwargs):
        return scope.float(
            scope.hyperopt_param(label,
                                 scope.loguniform(*args, **kwargs)))


    @validate_label
    def qloguniform(label, *args, **kwargs):
        return scope.float(
            scope.hyperopt_param(label,
                                 scope.qloguniform(*args, **kwargs)))

    @validate_label
    def normal(label, *args, **kwargs):
        return scope.float(
            scope.hyperopt_param(label,
                                 scope.normal(*args, **kwargs)))


    @validate_label
    def qnormal(label, *args, **kwargs):
        return scope.float(
            scope.hyperopt_param(label,
                                 scope.qnormal(*args, **kwargs)))


    @validate_label
    def lognormal(label, *args, **kwargs):
        return scope.float(
            scope.hyperopt_param(label,
                                 scope.lognormal(*args, **kwargs)))


    @validate_label
    def qlognormal(label, *args, **kwargs):
        return scope.float(
            scope.hyperopt_param(label,
                                 scope.qlognormal(*args, **kwargs)))
