#!/bin/sh

BACKEND_URL="http://localhost:3000";
export PYTHONPATH="TestServer/testrunner"

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

# Start the Python SDK test backend server. Send to background.
CMD="mono TestServer/bin/Debug/TestServer.exe $API_KEY"
eval "$CMD &"
echo "Backend server started. PID: $!"
BACKEND_PID=$!

sleep 5

# Set the parameters to the test runner
PARAMS=()
PARAMS+=(-s $BACKEND_URL)
PARAMS+=(-k $API_KEY)

# Start the test runner
python TestServer/testrunner/bin/trunner ${PARAMS[@]}
RET_CODE=$

cleanup

exit $RET_CODE