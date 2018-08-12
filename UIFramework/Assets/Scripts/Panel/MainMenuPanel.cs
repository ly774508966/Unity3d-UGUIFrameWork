using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuPanel : BasePanel {

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;//当弹出新的面板的时候，让主菜单面板 不再和鼠标交互
    }
    public override void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPushPanel(string panelTypeString)
    {
        UIPanelTypes panelType = (UIPanelTypes) System.Enum.Parse(typeof(UIPanelTypes), panelTypeString);
        UIManager.Instance.OpenPanel(panelType);
    }

}
