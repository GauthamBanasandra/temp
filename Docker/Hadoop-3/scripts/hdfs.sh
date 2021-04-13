cd /opt/hadoop-2.8.1/bin
./hdfs namenode -format

cd /opt/hadoop-2.8.1/sbin
./hadoop-daemon.sh start namenode
./hadoop-daemon.sh start secondarynamenode 
./hadoop-daemon.sh start datanode

hdfs dfs -mkdir -p /mr-history/tmp
hdfs dfs -mkdir -p /tmp
hdfs dfs -mkdir -p /mr-history/done
hdfs dfs -chown -R yarn:hadoop  /mr-history
hdfs dfs -chmod go+rwx /mr-history/tmp
hdfs dfs -chmod go+rwx /mr-history
hdfs dfs -chmod go+rwx /tmp