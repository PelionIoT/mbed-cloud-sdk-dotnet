# --------------------------------------------------------------------------
# Mbed Cloud DotNet SDK
# (C) COPYRIGHT 2017 Arm Limited
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# --------------------------------------------------------------------------
"""Generates DVCS version information

requirements:


see also:
https://git-scm.com/docs/git-shortlog
https://www.python.org/dev/peps/pep-0440/
https://pypi.python.org/pypi/semver
https://pypi.python.org/pypi/bumpversion
https://github.com/warner/python-versioneer

"""
import fileinput
import os
import sys
import shlex
import subprocess
from xml.etree import ElementTree


def write_out(**params):
    """Writes version info into version file inline"""
    target = os.path.join(
        os.path.dirname(os.path.dirname(__file__)), 'MbedCloudSDK', 'Common', 'Version.cs'
    )
    fh = fileinput.FileInput(target, inplace=True)
    try:
        for line in fh:
            for k, v in params.items():
                if line.startswith(k):
                    print('%s = "%s";  // auto' % (k, v))
                    params.pop(k)
                    break
            else:
                print(line.rstrip())
    finally:
        fh.close()

def get_csproj_version():
    target = os.path.join(
        os.path.dirname(os.path.dirname(__file__)), 'MbedCloudSDK', 'MbedCloudSDK.csproj'
    )
    tree = ElementTree.parse(target)
    for node in tree.iter():
        version = node.findall('VersionPrefix')
        if version:
            break
    else:
        raise KeyError('could not find csproj element')
    return version[0].text

def main():
    """Generates DVCS version information"""
    cmd = 'git rev-parse HEAD'
    commit_hash = subprocess.check_output(shlex.split(cmd)).strip().decode()
    cmd = 'git rev-list --count HEAD'
    commit_count = str(int(subprocess.check_output(shlex.split(cmd)).strip()))
    current_version = get_csproj_version()
    new_version = '%s.%s' % (current_version, commit_count)
    write_out( ** {
        '        public const string Commit': commit_hash,
        '        public const string VersionValue': new_version,
    })


if __name__ == '__main__':
    if len(sys.argv)==2 and sys.argv[1] == 'version':
        print(get_csproj_version())
    else:
        main()
