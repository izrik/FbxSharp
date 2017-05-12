
from fbxclass import *

all_classes = get_all_classes_from_file()

# re-arrange the hierarchy file
for cls in all_classes:
    if cls.parent:
        print('{} : {}'.format(cls.name, cls.parent.name))
    else:
        print(cls.name)
    print('')

