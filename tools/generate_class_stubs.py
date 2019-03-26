#!/usr/bin/env python3

from fbxclass import *

all_classes = get_all_classes_from_file()

# generate stubs for all classes
classes_by_name = {}
for cls in all_classes:
    name = cls.name
    if '<' in name: continue
    if '::' in name: continue
    name = name.split('<', 1)[0]
    if name not in classes_by_name:
        classes_by_name[name] = set()
    classes_by_name[name].add(cls)
for name in classes_by_name:
    filename = name + '.Generated.cs'
    s = ''
    s += 'using System;\n'
    s += '\n'
    s += 'namespace FbxSharp\n'
    s += '{\n'
    for cls in classes_by_name[name]:
        s += '    public partial class {}'.format(cls.name)
        if cls.parent:
            s += ' : {}'.format(cls.parent.name)
        s += '\n'
        s += '    {\n'
        s += '        public {}()\n'.format(cls.name)
        s += '        {\n'
        s += '            throw new NotImplementedException();\n'
        s += '        }\n'
        s += '    }\n'
        s += '\n'
    s += '}\n'
    with open(filename, 'w') as f:
        print(s, file=f)