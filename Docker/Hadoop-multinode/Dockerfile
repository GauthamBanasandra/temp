FROM ubuntu:focal

WORKDIR /root

SHELL ["/bin/bash", "-o", "pipefail", "-c"]

RUN echo APT::Install-Recommends "0"\; > /etc/apt/apt.conf.d/10disableextras
RUN echo APT::Install-Suggests "0"\; >>  /etc/apt/apt.conf.d/10disableextras

RUN apt-get -q update -y \
    && apt-get -q upgrade -y
RUN apt-get -q install -y --no-install-recommends openjdk-11-jdk
RUN apt-get -q install -y --no-install-recommends vim
RUN apt-get -q install -y --no-install-recommends ssh
RUN apt-get -q install -y --no-install-recommends pdsh

EXPOSE 8088
EXPOSE 50070
EXPOSE 9000
EXPOSE 9870
EXPOSE 8032

COPY scripts /opt/scripts
RUN chmod a+x /opt/scripts/*.sh
RUN /opt/scripts/pwdless-ssh.sh

RUN useradd -ms /bin/bash hduser
RUN groupadd hadoop
RUN usermod -a -G hadoop hduser

ENV PDSH_RCMD_TYPE ssh
ENV HADOOP_CONF_DIR /opt/hadoop-config
ENV HADOOP_HOME /opt/hadoop
ENV SPARK_HOME /opt/spark
ENV JAVA_HOME /usr/lib/jvm/java-11-openjdk-amd64
ENV PATH ${PATH}:${HADOOP_HOME}/bin:${SPARK_HOME}/bin

USER hduser
RUN /opt/scripts/pwdless-ssh.sh

RUN echo 'export PDSH_RCMD_TYPE=ssh' >> ~/.bashrc
RUN echo 'export HADOOP_CONF_DIR=/opt/hadoop-config' >> ~/.bashrc
RUN echo 'export HADOOP_HOME=/opt/hadoop' >> ~/.bashrc
RUN echo 'export SPARK_HOME=/opt/spark' >> ~/.bashrc
RUN echo 'export JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64' >> ~/.bashrc
RUN echo 'export PATH=${PATH}:${HADOOP_HOME}/bin:${SPARK_HOME}/bin' >> ~/.bashrc

USER root

# CMD ["/opt/scripts/setup.sh"]
