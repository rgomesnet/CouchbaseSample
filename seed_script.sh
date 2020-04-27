#!/bin/bash
cbc-bucket-create people-sample --bucket-type=couchbase -u Administrator -P password
cbq -u Administrator -p password -f=people_sample.txt
