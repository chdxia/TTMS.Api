pipeline {
  agent {label 'master'}
  options {
    skipStagesAfterUnstable()
    timeout(time: 1, unit: 'HOURS') 
  }
  environment {def server = ''}
  stages {
    stage('远程拉取') {
      steps {
        // 初始化参数
        script {server = getServer()}
        // 在目标服务器上获取最新代码
        sshCommand remote: server, command: 'cd /root/lrtest-api && git fetch'
      }
    }
    stage('远程构建') {
      steps {
        // 在目标服务器上构建docker镜像
        sshCommand remote: server, command: 'cd /root/lrtest-api/src && podman build -t lrtest -f /LRtest.Api/Dockerfile .'
      }
    }
    stage('远程启动') {
      steps {
        // 在目标服务器上停止容器、并根据新构建的docker镜像启动容器
        sshCommand remote: server, command: 'podman stop lrtest && podman run --rm -d -p 8082:80 --name lrtest lrtest'
      }
    }
  }
}


// 定义一个方法，返回ssh连接所需的信息
def getServer() {
  def remote = [:]
  remote.name = "ssh"
  remote.host = "chdxia.com"
  remote.port = 22
  remote.allowAnyHosts = true

  // 这里不展示明文密码，所以在jenkins凭据里提取
  withCredentials([usernamePassword(
    credentialsId: "f76fdeee-5bbb-46c2-8d2c-2916f45576c9",
    usernameVariable: "username",
    passwordVariable: "password")]) {
    remote.user = "${username}"
    remote.password = "${password}"
  }
  return remote
}
