using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanel : MonoBehaviour
{


   public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    public void DisplayPanel()
    {
        gameObject.SetActive(true);
    }
}
