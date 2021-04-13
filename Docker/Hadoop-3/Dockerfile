FROM ubuntu:focal

WORKDIR /root

SHELL ["/bin/bash", "-o", "pipefail", "-c"]

RUN echo APT::Install-Recommends "0"\; > /etc/apt/apt.conf.d/10disableextras
RUN echo APT::Install-Suggests "0"\; >>  /etc/apt/apt.conf.d/10disableextras

EXPOSE 8088
EXPOSE 50070
EXPOSE 9000

ENV DEBIAN_FRONTEND noninteractive

RUN apt-get -q update
RUN apt-get -q install -y --no-install-recommends ant
RUN apt-get -q install -y --no-install-recommends apt-utils
RUN apt-get -q install -y --no-install-recommends bats
RUN apt-get -q install -y --no-install-recommends build-essential
RUN apt-get -q install -y --no-install-recommends bzip2
RUN apt-get -q install -y --no-install-recommends clang
RUN apt-get -q install -y --no-install-recommends cmake
RUN apt-get -q install -y --no-install-recommends curl
RUN apt-get -q install -y --no-install-recommends doxygen
RUN apt-get -q install -y --no-install-recommends fuse
RUN apt-get -q install -y --no-install-recommends g++
RUN apt-get -q install -y --no-install-recommends gcc
RUN apt-get -q install -y --no-install-recommends git
RUN apt-get -q install -y --no-install-recommends gnupg-agent
RUN apt-get -q install -y --no-install-recommends hugo
RUN apt-get -q install -y --no-install-recommends libbcprov-java
RUN apt-get -q install -y --no-install-recommends libbz2-dev
RUN apt-get -q install -y --no-install-recommends libcurl4-openssl-dev
RUN apt-get -q install -y --no-install-recommends libfuse-dev
RUN apt-get -q install -y --no-install-recommends libprotobuf-dev
RUN apt-get -q install -y --no-install-recommends libprotoc-dev
RUN apt-get -q install -y --no-install-recommends libsasl2-dev
RUN apt-get -q install -y --no-install-recommends libsnappy-dev
RUN apt-get -q install -y --no-install-recommends libssl-dev
RUN apt-get -q install -y --no-install-recommends libtool
RUN apt-get -q install -y --no-install-recommends libzstd-dev
RUN apt-get -q install -y --no-install-recommends locales
RUN apt-get -q install -y --no-install-recommends make
RUN apt-get -q install -y --no-install-recommends maven
RUN apt-get -q install -y --no-install-recommends nodejs
RUN apt-get -q install -y --no-install-recommends node-yarn
RUN apt-get -q install -y --no-install-recommends npm
RUN apt-get -q install -y --no-install-recommends openjdk-8-jdk
RUN apt-get -q install -y --no-install-recommends pinentry-curses
RUN apt-get -q install -y --no-install-recommends pkg-config
RUN apt-get -q install -y --no-install-recommends python3
RUN apt-get -q install -y --no-install-recommends python3-pip
RUN apt-get -q install -y --no-install-recommends python3-pkg-resources
RUN apt-get -q install -y --no-install-recommends python3-setuptools
RUN apt-get -q install -y --no-install-recommends python3-wheel
RUN apt-get -q install -y --no-install-recommends rsync
RUN apt-get -q install -y --no-install-recommends shellcheck
RUN apt-get -q install -y --no-install-recommends software-properties-common
RUN apt-get -q install -y --no-install-recommends sudo
RUN apt-get -q install -y --no-install-recommends valgrind
RUN apt-get -q install -y --no-install-recommends zlib1g-dev
RUN apt-get -q install -y --no-install-recommends net-tools
RUN apt-get -q install -y --no-install-recommends vim
RUN apt-get -q install -y --no-install-recommends ssh
RUN apt-get -q install -y --no-install-recommends pdsh
RUN apt-get -q install -y --no-install-recommends wget

RUN service ssh start

RUN mkdir -p /opt/isa-l-src \
    && apt-get -q update \
    && apt-get install -y --no-install-recommends automake yasm \
    && apt-get clean \
    && curl -L -s -S \
      https://github.com/intel/isa-l/archive/v2.29.0.tar.gz \
      -o /opt/isa-l.tar.gz \
    && tar xzf /opt/isa-l.tar.gz --strip-components 1 -C /opt/isa-l-src \
    && cd /opt/isa-l-src \
    && ./autogen.sh \
    && ./configure \
    && make "-j$(nproc)" \
    && make install \
    && cd /root \
    && rm -rf /opt/isa-l-src

ENV JAVA_HOME /usr/lib/jvm/java-8-openjdk-amd64
ENV PDSH_RCMD_TYPE ssh

RUN wget -P /tmp https://mirrors.estointernet.in/apache/hadoop/common/hadoop-3.3.0/hadoop-3.3.0.tar.gz \
    && mkdir -p /opt/ \
    && tar xvzf /tmp/hadoop-3.3.0.tar.gz -C /opt

ENV HADOOP_HOME /opt/hadoop-3.3.0
ENV PATH $HADOOP_HOME/bin:$PATH

RUN echo 'export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64' > /etc/profile.d/java.sh
RUN echo 'export HADOOP_HOME=/opt/hadoop-3.3.0;export PATH=$HADOOP_HOME/bin:$PATH' > /etc/profile.d/hadoop.sh
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

# RUN cp $HADOOP_HOME/etc/hadoop/mapred-site.xml.template  $HADOOP_HOME/etc/hadoop/mapred-site.xml

# COPY files/core-site.xml $HADOOP_HOME/etc/hadoop/core-site.xml
# COPY files/hdfs-site.xml $HADOOP_HOME/etc/hadoop/hdfs-site.xml
# COPY files/mapred-site.xml $HADOOP_HOME/etc/hadoop/mapred-site.xml
# COPY files/yarn-site.xml $HADOOP_HOME/etc/hadoop/yarn-site.xml
# COPY files/yarn-env.sh $HADOOP_HOME/etc/hadoop/yarn-env.sh

RUN chown -R yarn:hadoop $HADOOP_HOME

COPY scripts/start-hdfs.sh $HOME
RUN chmod a+x $HOME/start-hdfs.sh
