#!/bin/bash
set -eo pipefail
IFS=$'\n\t'

OUTPUT_DIR="../docs/";

# Build Doxygen docs
doxygen ../ar.doxygen

mv ../docs/* ${SDK_DOCS}
