import dis
import sys
import io
import re
import inspect

functions_passed = list()


def get_globals(func_name, module):
    stdout_ = sys.stdout  # Keep track of the previous value.
    stream = io.StringIO()
    sys.stdout = stream

    dis.dis(getattr(module, func_name))  # prints opcodes to the stream

    sys.stdout = stdout_  # restore the previous stdout.
    opcodes = stream.getvalue()

    splited = re.split("\n", opcodes)
    globals_used = filter(lambda x: re.match(".*\sLOAD_GLOBAL\s.*", x), splited)
    globals_used = [re.search('\(\w+\)', y).group()[1:-1] for y in globals_used]

    globals_list = set()

    for global_var in globals_used:
        try:
            type_of = type(getattr(module, global_var)).__name__
            if type_of == 'function' and global_var not in functions_passed:
                functions_passed.append(global_var)
                globals_list.add(global_var)
                other_globals = get_globals(global_var, module)
                globals_list.join(other_globals)
            else:
                globals_list.add(global_var)
        except AttributeError:
            pass
    return globals_list


def get_needed_source(func_name, is_init=False):
    this_module = sys.modules['__main__']

    # Return get_notebook_code()
    needed_globals = get_globals(func_name, this_module)

    needed_source = ""
    needed_imports = ""

    for needed_global in needed_globals:
        val = this_module.__dict__.get(needed_global)
        try:
            if val.__class__.__name__ == 'module':
                needed_imports += '%s %s %s %s\n' % ('import', val.__name__, 'as', needed_global)
            else:
                if val.__module__ == '__main__':
                    needed_source += inspect.getsource(val) + '\n'
                else:
                    if val.__class__.__name__ == 'function':
                        package_name = val.__globals__['__package__']
                    else:
                        package_name = val.__module__
                    needed_imports += '%s %s %s %s' % \
                                      ('from', package_name, 'import', val.__name__)
                    if val.__name__ == needed_global:
                        needed_imports += '\n'
                    else:
                        needed_imports += '%s %s\n' % ('as', needed_global)
        except AttributeError as e:
            pass

    needed_source = needed_imports + needed_source + '\n'
    func_source = inspect.getsource(this_module.__dict__[func_name])
    if is_init:
        needed_source += re.sub('.*\n', 'if True:\n', func_source, 1)
    else:
        needed_source += func_source
    return needed_source + '\n'
