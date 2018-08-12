using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRoot : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        //List<UIPanelTypes> list = new List<UIPanelTypes>();
        //list.Add(UIPanelTypes.MainMenu);
        //UIManager.Instance.Init(list);
        UIManager.Instance.Init();
        UIManager.Instance.OpenPanel(UIPanelTypes.MainMenu);
	}
	

}
