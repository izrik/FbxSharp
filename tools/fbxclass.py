
import re

class FbxClass:
    name = ''
    parent = None
    children = None

    def __init__(self, name):
        self.name = re.sub(r'\s*\*\s*', '', name)
        self.children = []

    def __str__(self):
        return self.name

    def __repr__(self):
        return 'FbxClass(\'{}\')'.format(self.name)

def load_classes_from_file():
    line_number = 0
    root_classes = []
    all_classes = []
    parents = [None] * 8
    with open('fbx-class-hierarchy.txt') as f:
        for line in f.readlines():
            line_number += 1
            if line.lstrip().startswith('#'): continue
            class_name = line.lstrip()
            indent = (len(line) - len(class_name))//4
            class_name = class_name.strip()
            cls = FbxClass(class_name)
            all_classes.append(cls)

            parents[indent] = cls

            if indent > 0:
                cls.parent = parents[indent-1]
                cls.parent.children.append(cls)
            else:
                root_classes.append(cls)

    return all_classes, root_classes

def get_root_classes_from_file():
    all_classes, root_classes = load_classes_from_file()
    return root_classes

def get_all_classes_from_file():
    all_classes, root_classes = load_classes_from_file()
    return all_classes
