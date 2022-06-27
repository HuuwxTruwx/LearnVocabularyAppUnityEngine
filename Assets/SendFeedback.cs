using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendFeedback : MonoBehaviour
{
    public GameObject notice;
    public InputField topic;
    public InputField message;
    
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void HidePanel()
    {
        this.gameObject.SetActive(false);
    }

    public void DisPlayPanel()
    {
        gameObject.SetActive(true);
    }
    public void SendFeedBack()
    {
        PlayFabManager.instance.SendFeedBack(topic.text, message.text);
    }

    public void DisplayNotice()
    {
        StartCoroutine(Notice());
    }
    IEnumerator Notice()
    {
        yield return new WaitForSeconds(1);
        notice.SetActive(true);
        yield return new WaitForSeconds(1);
        notice.SetActive(false);
    }
}
