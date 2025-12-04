using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWindow : WindowRoot
{
    public RecordWindow recordwindow;

    protected override void InitWindow()
    {
         base.InitWindow();
    }
    void Start()
    {
        
    }
        
    void Update()
    {
        EnterRecordWindow();
    }
    private void EnterRecordWindow()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetWindowState(false);
            recordwindow.SetWindowState(true);
        }
    }
}
