#!/bin/bash
echo "Publish TODO WebAPI"  
dotnet publish -c Release -o app --self-contained --no-dependencies -r linux-musl-x64
