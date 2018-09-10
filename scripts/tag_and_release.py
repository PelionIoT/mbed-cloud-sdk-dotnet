import os
import subprocess
import sys
import urllib.request
import json


def git_url_ssh_to_https(url):
    """Convert a git url

    url will look like
    https://github.com/ARMmbed/mbed-cloud-sdk-python.git
    or
    git@github.com:ARMmbed/mbed-cloud-sdk-python.git
    we want:
    https://${GITHUB_TOKEN}@github.com/ARMmbed/mbed-cloud-sdk-python-private.git
    """
    path = url.split('github.com', 1)[1][1:].strip()
    new = 'https://{GITHUB_TOKEN}@github.com/%s' % path
    print('rewriting git url to: %s' % new)
    return new.format(GITHUB_TOKEN = os.getenv('GITHUB_TOKEN'))


def setup_git(tag=None):
    #setup git to use GITHUB_TOKEN
    #url = subprocess.check_output(['git', 'remote', 'get-url', 'origin'])
    url = subprocess.check_output(['git', 'ls-remote', '--get-url', 'origin'])
    new_url = git_url_ssh_to_https(url.decode())
    subprocess.check_call(['git', 'remote', 'set-url', 'origin', new_url])
    branch = os.getenv('CIRCLE_BRANCH')
    if branch == '': branch = 'master'
    branch_spec = 'origin/%s' % branch
    print(branch_spec)
    # On a tag build the HEAD is deteched, so checkout master
    if tag:
        subprocess.check_call(['git', 'checkout', 'master'])
    subprocess.check_call(['git', 'branch', '--set-upstream-to', branch_spec])

def tag(version):
    #tag with supplied version
    subprocess.check_call(['git', 'tag', '-a', version, '-m', 'release %s' % version])
    subprocess.check_call(['git', 'tag', '-f', 'latest'])
    subprocess.check_call(['git', 'push', '-f', 'origin', '--tags'])

def tag_beta(version):
    #tag with supplied version
    subprocess.check_call(['git', 'tag', '-a', version, '-m', 'release %s' % version])
    subprocess.check_call(['git', 'tag', '-f', 'beta'])
    subprocess.check_call(['git', 'push', '-f', 'origin', '--tags'])

def news():
    #commit news files
    subprocess.check_call(['git', 'add', 'CHANGELOG.md'])
    subprocess.check_call(['git', 'add', 'docs/news/*'])
    subprocess.check_call(['git', 'add', 'MbedCloudSDK/Common'])
    subprocess.check_call(['git', 'add', 'MbedCloudSDK/MbedCloudSDK.csproj'])
    subprocess.check_call(['git', 'commit', '-m', "Hear yea, hear yea. News O'Clock. [skip ci]"])
    subprocess.check_call(['git', 'push', 'origin'])

def slack(version):
    # posting message to slack
    body = {"text": ":its-coming-home: :checkered_flag: New version of :c-sharp: SDK released: {} :its-coming-home:".format(version)}
    myurl = "https://hooks.slack.com/services/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"
    req = urllib.request.Request(myurl)
    req.add_header('Content-Type', 'application/json; charset=utf-8')
    jsondata = json.dumps(body)
    jsondataasbytes = jsondata.encode('utf-8')   # needs to be bytes
    req.add_header('Content-Length', len(jsondataasbytes))
    response = urllib.request.urlopen(req, jsondataasbytes)


if __name__ == '__main__':
    if len(sys.argv) >= 1:
        if sys.argv[1] == 'tag':
            setup_git()
            tag(sys.argv[2])
        if sys.argv[1] == 'beta':
            setup_git()
            tag(sys.argv[2])
        if sys.argv[1] == 'news':
            setup_git(True)
            news()
            slack(sys.argv[2])
