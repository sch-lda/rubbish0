#!/bin/bash

read -p "请输入查询者ID(可直接回车): " user
user=${user:-MzXk} 
read -p "请输入查询目标SC名称(必填,不区分大小写): " nickname
nickname=${nickname:-shuaige66} 
read -p "请输入循环查询间隔(s)可不填: " sleep_time
sleep_time=${sleep_time:-930} 

url="https://hqshi.cn/api/post?from=Miniprogram&user=$user&nickname=$nickname&platform=default&expire=900"

while true; do
    curl -X GET "$url"
    sleep $sleep_time
done 