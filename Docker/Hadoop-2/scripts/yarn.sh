cd /opt/hadoop-2.8.1/sbin
./yarn-daemon.sh start resourcemanager
./yarn-daemon.sh start nodemanager
./mr-jobhistory-daemon.sh start historyserver 