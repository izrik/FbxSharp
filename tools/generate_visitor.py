#!/usr/bin/env python

from fbxclass import *

all_classes, root_classes = load_classes_from_file()

# generate stubs for all classes
classes_by_name = {}
for cls in all_classes:
    name = cls.name
    name = name.split('<', 1)[0]
    if name not in classes_by_name:
        classes_by_name[name] = set()
    classes_by_name[name].add(cls)
print('using System;')
print('')
print('namespace FbxSharp')
print('{')
print('    public partial class Visitor'.format(cls.name))
print('    {')
for cls in all_classes:
    varname = cls.name.replace('Fbx', '').lower()
    print('        public virtual void Visit({} {}) {{ }}'.format(cls.name,
                                                                  varname))
print('')
print('        /*********************************/')
print('')
print('        public void Accept(object obj, '
      'ISet<object> visitedObjects=null)')
print('        {')
print('            if (obj == null) return;')
print('            if (visitedObjects == null) visitedObjects = new HashSet<object>();')
print('            if (visitedObjects.Contains(obj)) return;')
print('            visitedObjects.Add(obj);')
print('')
for cls in root_classes:
    print('            if (obj is {})'.format(cls.name))
    print('                Accept{}(({})obj,'
          ' visitedObjects);'.format(cls.name, cls.name))
print('        }')
def print_accept_method(cls):
    varname = cls.name.replace('Fbx', '').lower()
    print('')
    print('        protected void Accept({} {}, '
          'ISet<object> visitedObjects=null)'.format(cls.name, varname))
    print('        {')
    print('            Visit({});'.format(varname))
    print('')
    print('            _Accept{}({}, visitedObjects);'.format(cls.name,
                                                              varname))
    print('')
    for cc in cls.children:
        print('            if (obj is {})'.format(cc.name))
        print('                Accept{}(({})obj,'
              ' visitedObjects);'.format(cc.name, cc.name))
    print('        }')
    for cc in cls.children:
        print_accept_method(cc)

for cls in root_classes:
    print_accept_method(cls)

print('    }')
print('}')
print('')

