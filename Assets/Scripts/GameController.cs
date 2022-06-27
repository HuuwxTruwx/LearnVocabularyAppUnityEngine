using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text loginNotice;
    public GameObject loading;
    public static GameController instance;
    private void Awake()
    {
        Application.targetFrameRate = 60;
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

    public void ChangeScene()
    {
        StartCoroutine(ChangeSceneAfterLogin());
    }

    public void ActiveLoading()
    {
        loading.SetActive(true);
    }
   
    IEnumerator ChangeSceneAfterLogin()
    {
        yield return new WaitForSeconds(2);
        if (loginNotice.text == "Login Succes")
        {
            PlayFabManager.instance.GetFoder();
            PlayFabManager.instance.GetVoca();
            PlayFabManager.instance.GetTotalScore();
            ManagerScene.instance.ChangeToScene("Main");
        }
        else
        {
            Debug.Log("not");
            yield return null;
        }         
    }

}
