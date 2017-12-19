#!/bin/bash

echo "Uploading to ${SDK_TAG}"
aws s3 sync --delete --cache-control max-age=3600 ${SDK_DOCS} s3://mbed-cloud-sdk-dotnet-dist/${SDK_TAG}/docs
aws s3 sync --delete --cache-control max-age=3600 ${SDK_REPORTS} s3://mbed-cloud-sdk-dotnet-dist/${SDK_TAG}/reports
echo "Uploading to latest"
aws s3 sync --delete --cache-control max-age=3600 ${SDK_DOCS} s3://mbed-cloud-sdk-dotnet-dist/latest/docs
aws s3 sync --delete --cache-control max-age=3600 ${SDK_REPORTS} s3://mbed-cloud-sdk-dotnet-dist/latest/reports