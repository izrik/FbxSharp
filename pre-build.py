#!/usr/bin/env python

import os
import sys

git_desc = os.popen('git describe --always --tags --abbrev=40 --long').read().rstrip()

print('Writing git description: {}\n'.format(git_desc))

filename = "AssemblyInfo.Git.cs"
if len(sys.argv) > 1 or sys.argv[1]:
    filename = sys.argv[1]

with open(filename, 'w') as f:
    f.write('using System.Reflection;\n')
    f.write('\n')
    f.write('[assembly: AssemblyInformationalVersion("')
    f.write(git_desc)
    f.write('")]\n')
