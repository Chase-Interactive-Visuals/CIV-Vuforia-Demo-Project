using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void AutoOpenClose(GameObject UISelected)
    {
        if (UISelected != null)
        {
            if (UISelected.activeSelf)
            {
                UISelected.SetActive(false);
            }
            else if (!UISelected.activeSelf)
            {
                UISelected.SetActive(true);
            }
        }
    }
    public void AutoOpenCloseWithParent(GameObject UISelected, GameObject ClosingMenu)
    {
        if (UISelected != null && ClosingMenu != null)
        {
            ClosingMenu.SetActive(false);
            UISelected.SetActive(true);
        }
    }
}
