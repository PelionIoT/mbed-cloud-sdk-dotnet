#!/bin/sh

# Start the Python SDK test backend server. Send to background.
CMD="mono TestServer/bin/Release/TestServer.exe $API_KEY"
eval "$CMD &"
echo "Backend server started. PID: $!"
BACKEND_PID=$!

# Start the test runner
python TestServer/testrunner/bin/trunner -s $BACKEND_URL -k $API_KEY
RET_CODE=$?

exit $RET_CODE