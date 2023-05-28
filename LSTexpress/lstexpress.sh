#!/bin/bash

url="https://hqshi.cn/api/post?from=Miniprogram&user=MzXk&nickname=7660&platform=default&expire=900"

while true; do
    curl -X GET "$url"
    sleep 930
done