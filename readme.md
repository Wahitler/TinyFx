## 分支结构： 

分支 | 说明
---|---
develop | 开发分支，合并到release
feature | 开发新功能分支，合并到develop
release | 测试分支,合并到master
master  | 发布分支
hotfix  | 线上发布版本BUG修复分支，合并到master

## 目录说明： 

目录名 | 说明
---|---
docs|文档
libs|第三.net方库
release  | 发布
resource   | 资源
samples   | demo
src   | 源代码



## 配置方案： 

配置 | 说明
---|---
Debug|开发环境
Test|测试环境
Simulation|仿真环境
Release|正式环境

---

## 注意事项：

### 密钥

######  在生成TinyFX之前需要导入密钥，否则会下边这样的错误：

> 无法导入以下密钥文件: TinyFX.pfx,该密钥文件可能受密码保护。若要更正此问题,请尝试再次导入证书，或手动将证书安装到具有以下密钥容器名称的强名称 CSP: VS_KEY_****************

###### 导入密钥步骤：

1. 运行Visual Studio 开发人员命令提示
2. 在命令提示符中定位到 tinyfx.pfx 所在目录
3. 在命令提示符中输入 sn -i TinyFx.pfx VS_KEY_****************
4. 生成TinyFx
