#!/bin/sh
set -e

BACKEND_URL="http://localhost:3000";

# Ensure we have API key
API_KEY="${MBED_CLOUD_API_KEY}"
if [ -z $API_KEY ]; then
  >&2 echo "API Key needs to be set using MBED_CLOUD_API_KEY env var";
  exit 1;
fi

echo ${MBED_CLOUD_API_KEY}
echo ${MBED_CLOUD_HOST}

mono --debug --profile=log:coverage,covfilter=+[MbedCloudSDK]MbedCloudSDK,output=int-output.mlpd TestServer/bin/Debug/TestServer.exe ${MBED_CLOUD_API_KEY} ${MBED_CLOUD_HOST} &

sleep 2

# Start the test runner
docker run --rm --net=host --name=testrunner_container \
-e "TEST_SERVER_URL=${BACKEND_URL}" \
-e "TEST_FIXTURES_DIR=/home/ubuntu/rpc_fixtures" \
-v /home/ubuntu/rpc_fixtures:/runner/test_fixtures \
-v /home/ubuntu/rpc_results:/runner/results \
${TESTRUNNER_DOCKER_IMAGE}
RET_CODE=$?

curl -X GET http://localhost:3000/_exit

exit $RET_CODE
