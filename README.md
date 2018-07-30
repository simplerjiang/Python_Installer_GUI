# Python安装及pip包管理（Windows窗体程序）
一个有界面的pip包管理！

## 图片

软件主页
![软件主页](https://github.com/simplerjiang/Python_Installer_GUI/blob/master/README_image/index.png)

pip包管理
![pip包管理](https://github.com/simplerjiang/Python_Installer_GUI/blob/master/README_image/pip.png)

软件更新
![软件更新](https://github.com/simplerjiang/Python_Installer_GUI/blob/master/README_image/UpdateFinish.png)

#### 更多功能请自己下载去看！
---

## 版本
2018/7/30日 发布V1.0版本 MD5值:a228012b0d04560f483e123d5ce4007d

如果你在其他地方下载的，请务必检查文件MD5值，否则出现其他状况作者不负责。

---

## 使用说明

是一个基于.net WinForm C#的窗体程序，功能包括了”部署Python环境" 和 “pip包管理”

#### 部署Python环境
使用此功能需要下载完整版，并且将解压包内所有文件内所有文件放在同一文件夹下，软件会自动
在你打开此功能后，检测你的CPU位数，将文件夹下的Python文件添加到系统环境（PATH）下。
所以请不要删除Python3.7文件，如果删除了，你就GG了。所以不推荐使用！除非你真的不懂怎么安装
Python！。

#### pip包管理
此功能是完全基于pip进行操作，所以如果你没有pip，那就不能正常使用！当然，上面"部署Python环境"
这个功能完成是自带pip的，但是需要使用指令 `python -m pip`的指令开启。当然，它已经实现pip内
的几乎所有功能，包括：`搜索模块` `更新模块列表` `更新模块及指定版本` `下载模块及指定版本` 
`卸载模块`等。

#### 指定特定路径
此功能是用于设定特定的Python环境，你在设置指定Python环境后，可以针对性的特定的Python进行pip包管理。
你需要点选Python环境下的`python.exe`文件夹。目前V1.0还没有加入`设置特定Python路径到环境路径（PATH）`。

#### 使用环境依赖

目标框架：.net framework 3.5 CP 

win10 自带.net 框架，可直接开启

server 2012 R2 进测试，在服务器功能中添加.net后可使用。

win7 需安装.net 3.5或以上

win8 未测试

---

## 软件下载
分为两个版本，完整版和简易版，区别在于完整版包含了Python3.7的32位以及64位，可以使用“设置Python环境" 功能

完整版：https://github.com/simplerjiang/Python_Installer_GUI/blob/master/Python%E5%8C%85%E7%AE%A1%E7%90%86%E5%B7%A5%E5%85%B7.rar

简易版：https://github.com/simplerjiang/Python_Installer_GUI/blob/master/PythonInstaller_GUI_V1.0.exe

