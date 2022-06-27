using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
   
    public static ManagerScene instance;
    
   
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

   
   
    public void ChangeToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


 
}
