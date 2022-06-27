using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TTS : MonoBehaviour
{
    AudioSource audio;
  
    public static TTS instance;
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
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
      
        audio = GetComponent<AudioSource>();

    }
    public void Play(string text)
    {

        StartCoroutine(GetAudioClip(text));
    }
    IEnumerator GetAudioClip(string text)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip
            ("http://api.voicerss.org/?key=&hl=en-us&v=Linda&c=MP3&f=ulaw_44khz_stereo&src=" + text, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                audio.PlayOneShot(myClip);
                
            }
        }
    }
}
