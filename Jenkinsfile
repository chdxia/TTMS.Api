pipeline {
  agent {label 'master'}
  options {
    skipStagesAfterUnstable()
    timeout(time: 1, unit: 'HOURS') 
  }
  environment {def server = ''}
  stages {
    stage('拉取代码') {
      steps {
        // 初始化参数
        script {
          server = getServer()
        }
        // 在目标服务器上拉取最新代码
        sshCommand remote: server, command: 'echo "Hello, World!"'
      }
    }
    stage('构建镜像') {
      steps {
        // 在目标服务器上构建docker镜像
        sshCommand remote: server, command: 'echo "Hello, World!"'
      }
    }
    stage('启动镜像') {
      steps {
        // 在目标服务器上启动docker镜像
        sshCommand remote: server, command: 'echo "Hello, World!"'
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
        passwordVariable: "password"
    )]) {
        remote.user = "${username}"
        remote.password = "${password}"
    }
    return remote
}