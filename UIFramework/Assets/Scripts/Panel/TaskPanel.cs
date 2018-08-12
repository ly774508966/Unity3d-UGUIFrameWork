﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TaskPanel : BasePanel {

    private CanvasGroup canvasGroup;

    void Start()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void OnEnter()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = true;

        canvasGroup.DOFade(1, .5f);
    }

    /// <summary>
    /// 处理页面的 关闭
    /// </summary>
    public override void OnConceal()
    {
        canvasGroup.blocksRaycasts = false;

        canvasGroup.DOFade(0, .5f);
    }

    public void OnClosePanel()
    {
        UIManager.Instance.HidePanel(UIPanelTypes.Task);
    }
}
