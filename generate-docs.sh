#!/bin/bash
set -eo pipefail
IFS=$'\n\t'

OUTPUT_DIR="docs/";

# Build Doxygen docs
doxygen ar.doxygen

mv docs/* ${SDK_DOCS}

# If AWS_ID and SECRET is defined, we push to S3
if [[ -n $AWS_ID && -n $AWS_SECRET ]]; then
  export AWS_ACCESS_KEY_ID=$AWS_ID;
  export AWS_SECRET_ACCESS_KEY=$AWS_SECRET;
  export AWS_DEFAULT_REGION=us-west-2;
  aws s3 sync --delete --cache-control max-age=3600 ${SDK_DOCS} s3://mbed-cloud-sdk-dotnet-dist/${SDK_TAG}/docs
  aws s3 sync --delete --cache-control max-age=3600 ${SDK_BUILD}/*.dll s3://mbed-cloud-sdk-dotnet-dist/${SDK_TAG}/build
  aws s3 sync --delete --cache-control max-age=3600 ${SDK_TESTS} s3://mbed-cloud-sdk-dotnet-dist/${SDK_TAG}/tests
fi