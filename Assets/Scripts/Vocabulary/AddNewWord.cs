using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class AddNewWord : MonoBehaviour
{
    public Voca vocabulary;
    public TMP_Text english;
    public TMP_Text vietnam;
    public GameObject notice;
    public TMP_Text noticeText;
    
    public void AddToList()
    {
        if (english.text != null && vietnam.text != null)
        {
            vocabulary.AddToList(english.text, vietnam.text);
            vocabulary.WriteToFile();
        }
    }
}
