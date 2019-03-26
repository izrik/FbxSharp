#!/usr/bin/env python

from fbxclass import *

root_classes = get_root_classes_from_file()

# print the hierarchy
def print_class(cls, indent=''):
    print('{}{}'.format(indent, cls.name, len(cls.children)))
    indent2 = indent + '    '
    for child in cls.children:
        print_class(child, indent2)

for cls in root_classes:
    print_class(cls)
