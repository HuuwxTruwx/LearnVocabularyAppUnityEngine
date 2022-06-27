using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddVoceElement : MonoBehaviour
{
    public VocaScriptAble vocaScriptAble;
    public OnFoder onFoder;

    public InputField english;
    public InputField vietnamese;
    public Voca voca;
    public DisplayVocaElement vocaElement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButtonAdd()
    {
        string key = english.text;
        string value = vietnamese.text;
        int know = 0;
        string foder = onFoder.onFoderName;
        Vocabulary v = new Vocabulary(foder, key, value, know);
        if(key != null && value != null)
        {
            //bool isAdd = voca.AddToList(key, value);
            //if (isAdd)
            //{
            //    voca.WriteToFile();
            //    Debug.Log("add");               
            //}
            vocaScriptAble.vocabularyDisplay.Add(v);
            vocaScriptAble.vocabularyList.Add(v);
            PlayFabManager.instance.SaveVoca();
            vocaElement.DisplayElement();
        }
        english.text = "";
        vietnamese.text = "";
        
    }
}
