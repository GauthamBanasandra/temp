git clone https://github.com/apache/hadoop.git
cd hadoop
mvn clean package -Dhttps.protocols=TLSv1.2 -DskipTests -Pnative,dist -Drequire.fuse -Drequire.openssl -Drequire.snappy -Drequire.valgrind -Drequire.zstd -Drequire.test.libhadoop -Pyarn-ui -Dtar > build-log-centos-7.log 2>&1 &
