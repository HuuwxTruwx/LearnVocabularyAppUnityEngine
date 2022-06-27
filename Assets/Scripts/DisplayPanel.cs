using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPanel : MonoBehaviour
{
    public GameObject panel;
    
    private void Start()
    {
        panel.SetActive(false);
    }
    public void DisPlayPanel()
    {
        
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
        else panel.SetActive(false);
    }

  
}
