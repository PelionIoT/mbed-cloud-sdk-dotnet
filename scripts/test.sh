#!/bin/sh

BACKEND_URL="http://localhost:3000";
export PYTHONPATH="TestServer/testrunner";

# Ensure we have API key
API_KEY="${MBED_CLOUD_API_KEY}"
if [ -z $API_KEY ]; then
  >&2 echo "API Key needs to be set using MBED_CLOUD_API_KEY env var";
  exit 1;
fi

mono --debug --profile=coverage TestServer/bin/Debug/TestServer.exe $API_KEY &

sleep 2

# Start the test runner
python TestServer/testrunner/bin/trunner -s $BACKEND_URL -k $API_KEY
RET_CODE=$?

curl -X GET http://localhost:3000/_exit

exit $RET_CODE