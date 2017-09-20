#!/bin/bash
set -eo pipefail
IFS=$'\n\t'

OUTPUT_DIR="docs/";

# Build Doxygen docs
doxygen ar.doxygen

# If AWS_ID and SECRET is defined, we push to S3
if [[ -n $AWS_ID && -n $AWS_SECRET ]]; then
  export AWS_ACCESS_KEY_ID=$AWS_ID;
  export AWS_SECRET_ACCESS_KEY=$AWS_SECRET;
  export AWS_DEFAULT_REGION=us-west-2;
  aws s3 sync --delete --cache-control max-age=3600 $OUTPUT_DIR s3://mbed-cloud-sdk-dotnet-dist/${SDK_TAG}/docs
fi