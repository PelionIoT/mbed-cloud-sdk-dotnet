#!/bin/sh

TMPDIR=$(mktemp -d 2>/dev/null || mktemp -d -t 'tmprunner');
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )";
ROOT_DIR=$(dirname "$DIR");
BACKEND_URL="${BACKEND_URL:-"http://localhost:3000"}";

cleanup() {
  echo "Test run finished. Cleaning up. Deleting tmp directory: $TMPDIR";
  if is_running $BACKEND_PID; then
    echo "Killing backend SDK server: $BACKEND_PID";
    kill $BACKEND_PID;
  fi
}

is_running() {
  if ps -p $1 >/dev/null; then
    return 0;
  fi
  return 1;
}

# Ensure we have API key
API_KEY="${MBED_CLOUD_API_KEY}"
if [ -z $API_KEY ]; then
  >&2 echo "API Key needs to be set using MBED_CLOUD_API_KEY env var";
  exit 1;
fi

git clone https://${GITHUB_TOKEN:-git}@github.com/ARMmbed/mbed-cloud-sdk-testrunner.git "$TMPDIR"
pip install -r $ROOT_DIR/requirements.txt
pip install -r $TMPDIR/requirements.txt
pip3 install -r $ROOT_DIR/requirements.txt
TRUNNER_DIR=$TMPDIR;
export PYTHONPATH="$TRUNNER_DIR:$ROOT_DIR:$PYTHONPATH"

# Start the Python SDK test backend server. Send to background.
CMD="mono $DIR/TestServer.exe $API_KEY"
eval "$CMD &"
echo "Backend server started. PID: $!"
BACKEND_PID=$!

sleep 10

if ! is_running $BACKEND_PID; then
  >&2 echo "Backend server did not start successfully."
  cleanup
  exit 1
fi

# Start the test runner
python $TRUNNER_DIR/bin/trunner -s $BACKEND_URL -k $API_KEY

cleanup

exit 0