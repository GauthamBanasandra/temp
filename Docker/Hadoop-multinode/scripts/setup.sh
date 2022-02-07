#!/usr/bin/env bash

cp -R $HADOOP_HOME/etc/hadoop /opt/hadoop-config
echo 'export HADOOP_LOG_DIR=/opt/hadoop-logs' >> $HADOOP_CONF_DIR/hadoop-env.sh
sed -i 's/localhost/hadoop-namenode/' $HADOOP_CONF_DIR/core-site.xml

mkdir /opt/hadoop-logs
chown -R :hadoop /opt/hadoop-logs
chmod g+w /opt/hadoop-logs

service ssh start
