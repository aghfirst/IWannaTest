using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance;
    public StartWindow startwindow;
    
    void Start()
    {
        Instance = this;
        ClearWindow();
        InitGame();
    }

    private void ClearWindow()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
        startwindow.SetWindowState(true);
    }

    private void InitGame()
    {
        ResourceSvc resourceSvc = GetComponent<ResourceSvc>();
        resourceSvc.InitSvc();
    }
}
