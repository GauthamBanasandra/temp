FROM ubuntu:focal

WORKDIR /root

SHELL ["/bin/bash", "-o", "pipefail", "-c"]

RUN echo APT::Install-Recommends "0"\; > /etc/apt/apt.conf.d/10disableextras
RUN echo APT::Install-Suggests "0"\; >>  /etc/apt/apt.conf.d/10disableextras

EXPOSE 8088
EXPOSE 50070
EXPOSE 9000
EXPOSE 9870

ENV DEBIAN_FRONTEND noninteractive
ENV HADOOP_DEV_PKG_NAME hadoop-3.4.0-SNAPSHOT

RUN apt-get -q update
RUN apt-get -q install -y --no-install-recommends bzip2
RUN apt-get -q install -y --no-install-recommends curl
RUN apt-get -q install -y --no-install-recommends fuse
RUN apt-get -q install -y --no-install-recommends libbz2-dev
RUN apt-get -q install -y --no-install-recommends libsnappy-dev
RUN apt-get -q install -y --no-install-recommends libssl-dev
RUN apt-get -q install -y --no-install-recommends libtool
RUN apt-get -q install -y --no-install-recommends libzstd-dev
RUN apt-get -q install -y --no-install-recommends locales
RUN apt-get -q install -y --no-install-recommends openjdk-8-jdk
RUN apt-get -q install -y --no-install-recommends rsync
RUN apt-get -q install -y --no-install-recommends shellcheck
RUN apt-get -q install -y --no-install-recommends software-properties-common
RUN apt-get -q install -y --no-install-recommends sudo
RUN apt-get -q install -y --no-install-recommends zlib1g-dev
RUN apt-get -q install -y --no-install-recommends net-tools
RUN apt-get -q install -y --no-install-recommends vim
RUN apt-get -q install -y --no-install-recommends ssh
RUN apt-get -q install -y --no-install-recommends pdsh
RUN apt-get -q install -y --no-install-recommends wget
RUN apt-get -q install -y --no-install-recommends dos2unix

RUN service ssh start

ENV JAVA_HOME /usr/lib/jvm/java-8-openjdk-amd64
ENV PDSH_RCMD_TYPE ssh

RUN wget -P /tmp http://192.168.100.101:12345/${HADOOP_DEV_PKG_NAME}.tar.gz \
    && mkdir -p /opt/ \
    && tar xvzf /tmp/${HADOOP_DEV_PKG_NAME}.tar.gz -C /opt

ENV HADOOP_HOME /opt/${HADOOP_DEV_PKG_NAME}
ENV PATH $HADOOP_HOME/bin:$PATH

RUN echo 'export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64' > /etc/profile.d/java.sh
RUN echo 'export HADOOP_HOME=/opt/${HADOOP_DEV_PKG_NAME};export PATH=$HADOOP_HOME/bin:$PATH' > /etc/profile.d/hadoop.sh
RUN echo "export JAVA_HOME=$JAVA_HOME" >> $HADOOP_HOME/etc/hadoop/hadoop-env.sh
RUN source /etc/profile.d/java.sh \
    && source /etc/profile.d/hadoop.sh

RUN useradd -ms /bin/bash yarn
RUN useradd -ms /bin/bash hdfs
RUN useradd -ms /bin/bash mapred

RUN groupadd hadoop
RUN usermod -a -G hadoop yarn
RUN usermod -a -G hadoop hdfs
RUN usermod -a -G hadoop mapred

RUN mkdir -p /var/data/hadoop/hdfs/nn \
    && mkdir -p /var/data/hadoop/hdfs/snn \
    && mkdir -p /var/data/hadoop/hdfs/dn \
    && chown hdfs:hadoop /var/data/hadoop/hdfs -R

RUN mkdir $HADOOP_HOME/logs \
    && chmod g+w $HADOOP_HOME/logs

COPY files/core-site.xml $HADOOP_HOME/etc/hadoop/core-site.xml
COPY files/hdfs-site.xml $HADOOP_HOME/etc/hadoop/hdfs-site.xml
COPY files/mapred-site.xml $HADOOP_HOME/etc/hadoop/mapred-site.xml
COPY files/yarn-site.xml $HADOOP_HOME/etc/hadoop/yarn-site.xml

RUN chown -R yarn:hadoop $HADOOP_HOME
RUN dos2unix $HADOOP_HOME/bin/*

USER hdfs
RUN ssh-keygen -t rsa -P '' -f ~/.ssh/id_rsa
RUN cat ~/.ssh/id_rsa.pub >> ~/.ssh/authorized_keys
RUN chmod 0600 ~/.ssh/authorized_keys
RUN $HADOOP_HOME/bin/hdfs namenode -format

USER yarn
RUN ssh-keygen -t rsa -P '' -f ~/.ssh/id_rsa
RUN cat ~/.ssh/id_rsa.pub >> ~/.ssh/authorized_keys
RUN chmod 0600 ~/.ssh/authorized_keys

USER root
RUN rm -rf /tmp/*
