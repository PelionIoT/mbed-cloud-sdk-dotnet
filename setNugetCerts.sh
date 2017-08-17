#!/bin/bash
yes "yes" | sudo certmgr -ssl -m https://go.microsoft.com
yes "yes" | sudo certmgr -ssl -m https://nugetgallery.blob.core.windows.net
yes "yes" | sudo certmgr -ssl -m https://nuget.org