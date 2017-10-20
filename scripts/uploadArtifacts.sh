#!/bin/bash

if [[ -n $AWS_ID && -n $AWS_SECRET ]]; then
  export AWS_ACCESS_KEY_ID=$AWS_ID;
  export AWS_SECRET_ACCESS_KEY=$AWS_SECRET;
  export AWS_DEFAULT_REGION=us-west-2;
  echo "Uploading to ${SDK_TAG}"
  aws s3 sync --delete --cache-control max-age=3600 ${SDK_DOCS} s3://mbed-cloud-sdk-dotnet-dist/${SDK_TAG}/docs
  aws s3 sync --delete --cache-control max-age=3600 ${SDK_REPORTS} s3://mbed-cloud-sdk-dotnet-dist/${SDK_TAG}/reports
fi