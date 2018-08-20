# Unity3d-UGUIFrameWork
*这是我根据网上的一些资料,自己在反复考虑修改后制作的基于UGUI的unity3d一套UI框架,主要负责UI界面之间的跳转*
# 使用步骤
* 1.使用时将unitypackage包导入unity中,制作好各个界面(每个界面最好在一个Panel下,这个panel及其子物体称为一个界面,即一个"panel").
* 2.将panel拖拽至Resource/UI/Panel下,做成预制体
* 3.在panel上添加一个组件,名字最好与panel名称一致,继承自-BasePanel
* 4.将panel的类型添加至UIPanelTypes这一枚举类型中
* 5.将panel的信息添加至Resource/UI/Config下的PanelInformation.json中,每一个panel新增一个对象,格式为json文件的示例格式(其中UIPanelType为枚举类型,用int表示,第一个枚举类型的int值是0,往下依次类推),
* 6.在游戏初始化的地方调用UIManager里的Init方法进行初始化
* 7.调用UIManager里面的OpenPanel来显示界面,HidePanel方法来隐藏界面,ClosePanel来隐藏并销毁界面(节约资源,适用于一次性界面)
* 8.在BasePanel中有8个可以重写的方法,在方法前有注释,大家可以根据需要进行重写
- - -
# 注意事项
* 1.UIManager是一个单例,他继承自Singleton,可以通过Instance访问他
* 2.请保证您的场景中存在一个名为"Canvas"的画布,且panel在该画布中制作并调整,最后成为预制体
* 3.若UIManager中已经指定了该场景中的Panel类型,调用OpenPanel时会在控制台提示"无法打开场景",关闭或隐藏场景同理
* 4.请不要将UIFrameWorkExample中的框架进行提取,因为那个不全面,有些地方存在问题,代码写的也不是很好.
* 5.UIFrameWorkExample是使用Unity2017版本制作，请大家使用相近版本打开
* 6.鉴于版本不同,我将UIFrameWorkExample工程以unitypackage的形式存储在百度云网盘中,需要参考的可以通过百度网盘下载以后导入自己的工程中.
* 7.百度网盘链接 https://pan.baidu.com/s/1cNxRcdLin4G3wzR8QEwNrg 密码：iq9l
* 8.如果百度网盘链接失效,请及时联系我,我会更新他.QQ:1976763043,邮箱:1976763043@qq.com
- - -
# UIFrameWorkExample截图
![](https://i.imgur.com/ZwV1SyK.jpg)
![](https://i.imgur.com/92DAd6K.jpg)
![](https://i.imgur.com/N4aWQQs.jpg)
