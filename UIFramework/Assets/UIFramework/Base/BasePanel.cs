using UnityEngine;
using System.Collections;

public class BasePanel : MonoBehaviour {

    //window信息类
    public PanelInfo panelInfo;

    /// <summary>
    /// 为windowInfo赋值
    /// </summary>
    /// <param name="oldWindow"></param>
    public void Copy(PanelInfo oldPanel)
    {
        panelInfo = new PanelInfo();
        panelInfo.PanelName = oldPanel.PanelName;
        panelInfo.PanelPath = oldPanel.PanelPath;
        panelInfo.UIPanelType = oldPanel.UIPanelType;
    }
    /// <summary>
    /// 创建前期 主要用于寻找view上的组件
    /// </summary>
    public virtual void OnBeforeEnter()
    {

    }

    /// <summary>
    /// 创建成功 主要用于逻辑注册
    /// </summary>
    public virtual void OnEnter()
    {

    }

    /// <summary>
    /// 当在该界面上再打开界面时,暂停该界面
    /// </summary>
    /// 
    public virtual void OnPause()
    {

    }

    /// <summary>
    /// 当在关闭该界面上打开的界面时,恢复该界面
    /// </summary>
    public virtual void OnResume()
    {

    }

    /// <summary>
    /// 当暂时隐藏这个界面时
    /// </summary>
    public virtual void OnConceal()
    {

    }

    /// <summary>
    /// 当暂时隐藏后重新打开界面时
    /// </summary>
    public virtual void OnShow()
    {

    }

    /// <summary>
    /// 界面关闭之前
    /// </summary>
    public virtual void OnBeforeClose()
    {
    }

    /// <summary>
    /// 界面关闭
    /// </summary>
    public virtual void OnClose()
    {
    }

    public void DestoryMyself()
    {
        Destroy(this.gameObject);
    }
}
