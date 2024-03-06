# TTMS (Team Task Management System)

<p style="display: flex">
  <a href="https://github.com/dotnet/aspnetcore">
    <img src="https://img.shields.io/badge/aspnetcore-6.0-brightgreen.svg" alt="aspnetcore">
  </a>
  <a href="https://github.com/dotnetcore/FreeSql">
    <img src="https://img.shields.io/badge/freesql-3.2.800-brightgreen.svg" alt="freesql">
  </a>
</p>


基于aspnetcore开发的项目任务管理系统

关键词：需求管理、BUG管理、版本管理、周报统计、自动化测试

### 技术栈（PgSql&Nginx&Jenkins都是自建服务）

前端：Vue3+TS+ElementUI（[vue-pure-admin](https://github.com/pure-admin/vue-pure-admin)模板）

后端：.Net 6

数据库：PgSql + FreeSql

网关：Nginx

部署环境：Linux + Docker

CI/CD：Jenkins

文件存储：QiniuCloud

### 传送门

项目演示传送门：https://ttms.chdxia.com

API文档传送门：https://ttms.chdxia.com/swagger

Hangfire传送门：https://ttms.chdxia.com/hangfire

Jenkins传送门：https://jenkins.chdxia.com

前端仓库传送门：https://github.com/chdxia/TTMS.Web

TTMS生命周期流程图: https://github.com/chdxia/TTMS.Document/blob/master/TTMSProcess.png

> *提示：请修改./src/TTMS.Api/appsettings.Dev.json中的配置信息
