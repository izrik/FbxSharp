#!/usr/bin/env python

from fbxclass import *

all_classes = get_all_classes_from_file()

root_classes = [cls for cls in all_classes if cls.name == 'FbxObject']
fbxobject = root_classes[0]


def traverse(cls, s=None):
    if s is None:
        s = set()
    s.add(cls)
    for cc in cls.children:
        traverse(cc, s)
    return s

all_classes = traverse(fbxobject)

# generate stubs for all classes
classes_by_name = {}
for cls in all_classes:
    name = cls.name
    name = name.split('<', 1)[0]
    if name not in classes_by_name:
        classes_by_name[name] = set()
    classes_by_name[name].add(cls)
print('using System;')
print('using System.IO;')
print('using System.Collections.Generic;')
print('')
print('namespace FbxSharp')
print('{')
print('    public partial class ObjectPrinter')
print('    {')
print('        public void Print(object obj, TextWriter writer=null)')
print('        {')
print('            if (obj == null) return;')
print('            if (writer == null) writer = Console.Out;')
if root_classes:
    print('')
for cls in root_classes:
    print('            if (obj is {})'.format(cls.name))
    print('                Print{}(({})obj, writer);'.format(cls.name,
                                                             cls.name))
print('        }')


def generate_type_specific_methods(cls):
    varname = 'obj'
    print('')
    print('        protected void Print{}({} {}, '
          'TextWriter writer)'.format(cls.name, cls.name, varname))
    print('        {')
    print('            _Print{}({}, writer);'.format(cls.name, varname))
    print('')
    for cc in cls.children:
        print('            if (obj is {})'.format(cc.name))
        print('                Print{}(({})obj,'
              ' writer);'.format(cc.name, cc.name))
    print('        }')
    for cc in cls.children:
        generate_type_specific_methods(cc)

for cls in root_classes:
    generate_type_specific_methods(cls)

print('    }')
print('}')
print('')

