FROM ubuntu:focal

WORKDIR /root

SHELL ["/bin/bash", "-o", "pipefail", "-c"]

RUN echo APT::Install-Recommends "0"\; > /etc/apt/apt.conf.d/10disableextras
RUN echo APT::Install-Suggests "0"\; >>  /etc/apt/apt.conf.d/10disableextras

EXPOSE 8088
EXPOSE 50070

RUN apt-get -q update \
    && apt-get -q install -y --no-install-recommends \
    wget \
    software-properties-common \
    sudo \
    openjdk-8-jdk \
    net-tools

ENV JAVA_HOME /usr/lib/jvm/java-8-openjdk-amd64

RUN wget -P /tmp https://archive.apache.org/dist/hadoop/common/hadoop-2.8.1/hadoop-2.8.1.tar.gz \
    && mkdir -p /opt/ \
    && tar xvzf /tmp/hadoop-2.8.1.tar.gz -C /opt

ENV HADOOP_HOME /opt/hadoop-2.8.1
ENV PATH $HADOOP_HOME/bin:$PATH

RUN echo 'export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64' > /etc/profile.d/java.sh
RUN echo 'export HADOOP_HOME=/opt/hadoop-2.8.1;export PATH=$HADOOP_HOME/bin:$PATH' > /etc/profile.d/hadoop.sh
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

RUN cp $HADOOP_HOME/etc/hadoop/mapred-site.xml.template  $HADOOP_HOME/etc/hadoop/mapred-site.xml

# COPY $HADOOP_HOME/etc/hadoop/core-site.xml $HADOOP_HOME/etc/hadoop/core-site.xml.orig
# COPY $HADOOP_HOME/etc/hadoop/hdfs-site.xml $HADOOP_HOME/etc/hadoop/hdfs-site.xml.orig
# COPY $HADOOP_HOME/etc/hadoop/mapred-site.xml $HADOOP_HOME/etc/hadoop/mapred-site.xml.orig
# COPY $HADOOP_HOME/etc/hadoop/yarn-site.xml $HADOOP_HOME/etc/hadoop/yarn-site.xml.orig
# COPY $HADOOP_HOME/etc/hadoop/yarn-env.sh $HADOOP_HOME/etc/hadoop/yarn-env.sh.orig

COPY files/core-site.xml $HADOOP_HOME/etc/hadoop/core-site.xml
COPY files/hdfs-site.xml $HADOOP_HOME/etc/hadoop/hdfs-site.xml
COPY files/mapred-site.xml $HADOOP_HOME/etc/hadoop/mapred-site.xml
COPY files/yarn-site.xml $HADOOP_HOME/etc/hadoop/yarn-site.xml
COPY files/yarn-env.sh $HADOOP_HOME/etc/hadoop/yarn-env.sh

RUN chown -R yarn:hadoop $HADOOP_HOME

COPY scripts/start-hdfs.sh $HOME
RUN chmod a+x $HOME/start-hdfs.sh
CMD [ "/bin/bash", "/root/start-hdfs.sh" ]

# USER hdfs
# RUN cd $HADOOP_HOME/bin \
#     && ./hdfs namenode -format
# RUN cd $HADOOP_HOME/sbin \
#     && ./hadoop-daemon.sh start namenode \
#     && ./hadoop-daemon.sh start secondarynamenode \
#     && ./hadoop-daemon.sh start datanode

# RUN cd $HADOOP_HOME/bin \
#     && ./hdfs dfs -mkdir -p /tmp \
#     && ./hdfs dfs -mkdir -p /mr-history/tmp \
#     && ./hdfs dfs -mkdir -p /mr-history/done \
#     && ./hdfs dfs -chown -R yarn:hadoop  /mr-history \
#     && ./hdfs dfs -chmod go+rwx /mr-history/tmp \
#     && ./hdfs dfs -chmod go+rwx /tmp

# USER yarn
# RUN cd $HADOOP_HOME/sbin \
#     && ./yarn-daemon.sh start resourcemanager \
#     && ./yarn-daemon.sh start nodemanager \
#     && ./mr-jobhistory-daemon.sh start historyserver
