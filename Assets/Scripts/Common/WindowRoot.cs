using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowRoot : MonoBehaviour
{
    protected ResourceSvc resourceSvc;
    public void SetWindowState(bool ifActive)
    {
        if (gameObject.activeSelf != ifActive)
        {
            gameObject.SetActive(ifActive);
        }

        if (ifActive)
        {
            InitWindow();
        }
        else
        {
            ClearWindow();
        }
    }

    protected virtual void InitWindow()
    {
        resourceSvc = ResourceSvc.Instance;
    }

    protected virtual void ClearWindow()
    {
        resourceSvc = null;
    }
}
