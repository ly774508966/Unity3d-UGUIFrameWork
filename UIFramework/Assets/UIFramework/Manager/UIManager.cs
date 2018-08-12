using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;

public class UIManager:SingLeton<UIManager> {

    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
    //界面栈,控制界面的显示与隐藏
    private Stack<BasePanel> panelStack;
    //临时数组,存储已经被实例化的面板
    private List<BasePanel> panelDict;
    //存储所有的面板
    private List<PanelInfo> panelinfoList;

    public void Init()
    {
        panelStack = new Stack<BasePanel>();
        panelDict=new List<BasePanel>();
        panelinfoList=new List<PanelInfo>();
        TextAsset ta = Resources.Load<TextAsset>("UI/Config/PanelInformation");
        panelinfoList = JsonMapper.ToObject<List<PanelInfo>>(ta.text);
        
    }
    public void Init(List<UIPanelTypes> uiPanelTypes)
    {
        Init();
        for (int i=0;i<panelinfoList.Count;)
        {
            if (!uiPanelTypes.Contains(panelinfoList[i].UIPanelType))
            {
                panelinfoList.Remove(panelinfoList[i]);
            }
            else
            {
                i++;
            }
        }
    }
    public void OpenPanel(UIPanelTypes panelType)
    {
        BasePanel bp = null;
        PanelInfo pi = null;
        if (panelStack.Count > 0)
        {
            bp = panelStack.Peek();
            bp.OnPause();
        }
        if (panelDict.Contains(GetBasePanel(panelType)))
        {
            bp = GetBasePanel(panelType);
            panelStack.Push(bp);
            bp.OnShow();
        }
        else
        {
            pi = GetPanelInfo(panelType);
            if (pi == null)
            {
                Debug.LogError(panelType+":无法打开此前页面");
                return;
            }
            GameObject instPanel = GameObject.Instantiate(Resources.Load(pi.PanelPath)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            BasePanel bw = instPanel.GetComponent<BasePanel>();
            bw.Copy(pi);
            panelDict.Add(bw);
            panelStack.Push(bw);
            bw.OnBeforeEnter();
            bw.OnEnter();
        }
    }

    public void HidePanel(UIPanelTypes uiWindowType)
    {

        BasePanel bp = GetBasePanel(uiWindowType);
        if (panelDict.Contains(bp))
        {
            while (true)
            {
                bp = panelStack.Pop();
                bp.OnConceal();
                if (bp.panelInfo.UIPanelType == uiWindowType)
                    break;
            }
            if (panelStack.Count >= 1)
            {
                bp = panelStack.Peek();
                bp.OnResume();
            }
        }
    }

    public void ClosePanel(UIPanelTypes panelType)
    {
        BasePanel bp = GetBasePanel(panelType);
        if (panelDict.Contains(bp))
        {
            while (true)
            {
                bp = panelStack.Pop();
                bp.OnBeforeClose();
                bp.OnClose();
                if (bp.panelInfo.UIPanelType == panelType)
                {
                    panelDict.Remove(bp);
                    bp.DestoryMyself();
                    break;
                }
                panelDict.Remove(bp);
                bp.DestoryMyself();
            }
            if (panelStack.Count >= 1)
            {
                bp = panelStack.Peek();
                bp.OnResume();
            }
        }

    }

    /// <summary>
    /// 通过UIWindowType获取WindowInfo
    /// </summary>
    /// <param name="uiWindowType">窗体类型</param>
    /// <returns>该窗体的信息</returns>
    public BasePanel GetBasePanel(UIPanelTypes uiWindowType)
    {
        foreach (var item in panelDict)
        {
            if (item.panelInfo.UIPanelType == uiWindowType)
                return item;
        }
        return null;
    }

    public PanelInfo GetPanelInfo(UIPanelTypes uiWindowType)
    {
        foreach (var item in panelinfoList)
        {
            if (item.UIPanelType == uiWindowType)
                return item;
        }
        return null;
    }
}
