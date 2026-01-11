<h1 align="center"><img src="https://foruda.gitee.com/avatar/1677165732744604624/7158691_java-and-net_1677165732.png!avatar100" alt="Organization Logo.png" /></h1>
<h1 align="center">TopskyHotelManagementSystem</h1>
<p align="center">
	<a href='https://gitee.com/java-and-net/TopskyHotelManagementSystem/stargazers'><img src='https://gitee.com/java-and-net/TopskyHotelManagementSystem/badge/star.svg?theme=white' alt='star'></img></a>
        <a href='https://gitee.com/java-and-net/TopskyHotelManagementSystem/members'><img src='https://gitee.com/java-and-net/TopskyHotelManagementSystem/badge/fork.svg?theme=white' alt='fork'></img></a>
        <a href='https://img.shields.io/badge/license-MIT-000000.svg'><img src="https://img.shields.io/badge/license-MIT-000000.svg" alt=""></img></a>
        <a href='https://img.shields.io/badge/language-C#-red.svg'><img src="https://img.shields.io/badge/language-CSharp-red.svg" alt=""></img></a>
</p>
<div align="center">
	<p>中文文档 | <a href="./README.en.md">English Document</a></p>
</div>

#  :exclamation: 重要说明：

**1.目前master分支随v2.10.x版本变动而变动，v2.8.x和v2.0.x版本以及v1.x版本均以归档，因此想要v1.x和v2.0.x版本的可移步至对应分支地址:<br/>
    v1.x分支：https://gitee.com/java-and-net/TopskyHotelManagerSystem/tree/v1.x/<br/>
    v2.x分支：https://gitee.com/java-and-net/TopskyHotelManagementSystem/tree/v2.0.x<br/> 
    v2.8.x分支：https://gitee.com/java-and-net/TopskyHotelManagementSystem/tree/v2.8.x**

**2.程序版本号规范将固定为x.x.x.x，第一位为当前程序版本，第二位为当前程序框架版本，第三位为功能大变更版本，第四位为日常修复版本，例如：基于NET 8框架的2.0版本，对应的版本号是2.8.0.0，往后的NET 9将会是2.9.0.0，并以此类推。**

**3.该项目正式进入维护阶段，不再新增任何功能。同时，我们很高兴地宣布，TopSkyHotelManagementSystem的移动端开发工作正式启动，具体仓库地址为：[TopSkyHotelManagementSystem-MAUI](https://gitee.com/java-and-net/topsky-hotel-management-system-maui)，该项目基于.NET 8的MAUI进行开发，目前仅考虑安卓端，其他暂不具备测试条件。**

#  :pray: 引用的开源项目：

1. ##### Fody——将所有dll打包成exe应用程序。[Fody,MIT开源协议](https://github.com/Fody/Fody)      

2. ##### SQLSugar，国内最受欢迎ORM框架[SQLSugar。 [Apache-2.0开源协议](https://gitee.com/dotnetchina/SqlSugar) 

4. ##### **RestSharp——Simple REST and HTTP API Client for .NET。[RestSharp,Apache-2.0开源协议](https://github.com/restsharp/RestSharp)**

5. ##### AntdUI——👚 基于 Ant Design 设计语言的 Winform 界面库。[AntdUI,Apache-2.0开源协议](https://gitee.com/antdui/AntdUI)

#  :exclamation: 本项目说明：

1、在对本项目进行二次开发时，请遵循 MIT 开源协议。所有引用的其他开源项目均采用其各自的开源协议。使用这些开源项目时，请务必在项目介绍中添加相应的声明，并按照各自的开源协议进行开源等操作。

2、有bug欢迎提出issue！或进行评论

3、本系统UI框架主要基于AntdUI进行创建，在此特别声明！

4、关于数据库脚本问题，请先移步至数据库脚本文件夹下，选择Mysql版本或PostgreSQL版本任意文件夹下载Data和Table两个文件，再数据库中先执行Table.sql，再执行Data.sql!

5、本项目已基于SQL Sugar框架支持多数据库(主流)，以下是目前已通过测试的数据库表格：

| 数据库     | 版本             | 支持建库建表(Y/N) | 通过(Y/N)                                            |
| ---------- | ---------------- | ----------------- | ---------------------------------------------------- |
| MariaDB    | 10.11.10-MariaDB | Y                 | Y                                                    |
| PostgreSQL | 130020           | Y                 | Y                                                    |
| MySQL      | 5.7+             | Y                 | Y                                                    |
| SQL Server | 2022             | Y                 | Y                                                    |
| Oracle     | Unknown          | N                 | 请参照SQLSugar文档([果糖网](https://www.donet5.com)) |

#  :thought_balloon: 开发目的：

在现如今发展迅速的酒店行业，随着酒店的日常工作增加，已经很难用人工去进行处理，一些繁琐的数据也可能会因为人工的失误而造成酒店的一些损失，因此很需要一款可以协助酒店进行内部管理的管理软件。

#  :mag_right: 系统开发环境：

操作系统：Windows 11(x64)

开发工具：Microsoft Visual Studio 2022(系统最新版本)

数据库：MariaDB(强烈推荐！)

数据库管理工具：Dbgate

开发语言：C#语言、T-SQL语言

开发平台：.Net

开发框架：.Net 8

开发技术：.NET 8 WinForm

#  :open_file_folder: 系统结构：
```tree
EOM.Client.TopskyHotelManagementSystem
├─ .git
├─ .gitignore
├─ EOM.Client.TopskyHotelManagementSystem.sln
├─ FodyWeavers.xml
├─ LICENSE
├─ README.md
├─ EOM.TopskyHotelManagementSystem.Common
├─ EOM.TopskyHotelManagementSystem.FormUI
│    ├─ .gitignore
│    ├─ App.config
│    ├─ AppFunction
│    ├─ AppInterface
│    ├─ AppMain
│    ├─ AppUserControls
│    ├─ FodyWeavers.xml
│    ├─ FodyWeavers.xsd
│    ├─ Logo
│    ├─ Program.cs
│    ├─ Properties
│    ├─ Resources
├─ SYS.Library
├─ 数据库脚本
├─ 项目效果图
└─ 项目相关文档
```

#  :chart_with_upwards_trend: 系统数据库关系图(由PDMAN软件生成) :loudspeaker: 
[数据库关系图](https://oscode.top/project/tshotel/db_design.html)

#  :books: 系统功能模块汇总：

| 功能汇总       |              |              |          |          |              |              |
| -------------- | ------------ | ------------ | -------- | -------- | ------------ | ------------ |
| (前台)客房管理 | 预约房间     | 入住房间     | 结算退房 | 转换房间 | 查看用户信息 | 修改房间状态 |
| (前台)用户管理 | 用户信息展示 | 搜索用户信息 | 添加客户 |          |              |              |
| (前台)商品消费 | 商品列表     | 搜索商品信息 | 商品消费 | 消费信息 |              |              |

#  :books: 多平台代码仓库汇总：

| 平台  | 仓库地址                                                               | 仓库简介                                     | 开源协议        | 依赖项目        |
|-----|--------------------------------------------------------------------|------------------------------------------|-------------|-------------|
| PC端 | https://gitee.com/java-and-net/TopskyHotelManagementSystem         | 基于Net8 WinForm平台开发(无业务逻辑)，针对中小型酒店设计的管理系统 | [MIT License](https://gitee.com/java-and-net/TopskyHotelManagementSystem/blob/master/LICENSE) | [WebApi](https://gitee.com/java-and-net/topsky-hotel-management-system-web-api)|
| 网页端 | https://gitee.com/java-and-net/topsky-hotel-management-system-vue3 | 基于Vue3开发的针对中小型酒店设计的管理系统                  | [MIT License](https://gitee.com/java-and-net/topsky-hotel-management-system-vue3/blob/Main/LICENSE) | [WebApi](https://gitee.com/java-and-net/topsky-hotel-management-system-web-api) |
| 安卓端 | https://gitee.com/java-and-net/topsky-hotel-management-system-maui | 基于Net8 MAUI平台开发的移动端项目                    | [MIT License](https://gitee.com/java-and-net/topsky-hotel-management-system-maui/blob/Main/LICENSE) | [WebApi](https://gitee.com/java-and-net/topsky-hotel-management-system-web-api) |
| 服务端 | https://gitee.com/java-and-net/topsky-hotel-management-system-web-api | 基于.Net8搭配SQLSugar框架构建的TS酒店管理系统后端API项目，主要服务于Client、Web、Android端    | [MIT License](https://gitee.com/java-and-net/topsky-hotel-management-system-web-api/blob/master/LICENSE) |

#  :family: 项目作者：

**原创团队：Jackson、Benjamin、Bin、Jonathan**

**后期维护团队：易开元(Easy Open Meta)**

#  :computer: 项目运行部署：

**下载并安装.NET 8及以上SDK版本。**
**下载并安装Microsoft Visual Studio Professional 2022及以上版本，并通过下载Zip包解压，打开.sln后缀格式文件运行。**

#  :inbox_tray: 开源协议：

[MIT Linsense](https://gitee.com/java-and-net/TopskyHotelManagementSystem/blob/master/LICENSE)

#  :inbox_tray: 依赖项目开源协议：

Fody [MIT Linsense](https://github.com/Fody/Fody/blob/master/License.txt)

RestSharp [Apache-2.0 Linsense](https://github.com/restsharp/RestSharp/blob/dev/LICENSE.txt)

AntdUI [Apache-2.0 Linsense](https://gitee.com/AntdUI/AntdUI/blob/main/LICENSE)

[![java-and-net/TopskyHotelManagementSystem](https://gitee.com/java-and-net/TopskyHotelManagementSystem/widgets/widget_card.svg?colors=4183c4,ffffff,ffffff,e3e9ed,666666,9b9b9b)](https://gitee.com/java-and-net/TopskyHotelManagerSystem)