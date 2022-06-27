using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVocaElement : MonoBehaviour
{
    public VocaScriptAble vocaScriptAble;

    public Voca voca;
    public GameObject vocaElement;
    Button update;
    Button delete;
    // Start is called before the first frame update
    void Start()
    {
        DisplayElement();
       
    }

    public void DisplayElement()
    {
        ClearDisPlayElement();
        GameObject temp;
        for (int i = 0; i < vocaScriptAble.vocabularyDisplay.Count; i++)
        {
            temp = Instantiate(vocaElement, transform);
            temp.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = vocaScriptAble.vocabularyDisplay[i].english;
            temp.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = vocaScriptAble.vocabularyDisplay[i].vietnam;
            update = temp.transform.GetChild(2).GetComponent<Button>();
            update.AddEventListener(i, OnUpdateButtonClick);
            delete = temp.transform.GetChild(3).GetComponent<Button>();
            delete.AddEventListener(i, OnDeleteButtonClick);
        }
    }
    void OnUpdateButtonClick(int i)
    {
        string key = transform.GetChild(i).GetChild(0).GetComponent<InputField>().text;
        string value = transform.GetChild(i).GetChild(1).GetComponent<InputField>().text;
        string foder = vocaScriptAble.vocabularyDisplay[i].foderName;
        int know = vocaScriptAble.vocabularyDisplay[i].know;
        Vocabulary v = new Vocabulary(foder, key, value, know);
        vocaScriptAble.vocabularyList.Remove(vocaScriptAble.vocabularyDisplay[i]);
        vocaScriptAble.vocabularyDisplay.Remove(vocaScriptAble.vocabularyDisplay[i]);
        vocaScriptAble.vocabularyList.Add(v);
        vocaScriptAble.vocabularyDisplay.Add(v);
        PlayFabManager.instance.SaveVoca();
        //voca.UpdateList(i,key,value);
        //voca.WriteToFile(); 
        DisplayElement();

    }

    void OnDeleteButtonClick(int i)
    {
        Debug.Log(i);
        vocaScriptAble.vocabularyList.Remove(vocaScriptAble.vocabularyDisplay[i]);
        vocaScriptAble.vocabularyDisplay.Remove(vocaScriptAble.vocabularyDisplay[i]);     
        PlayFabManager.instance.SaveVoca();
        //voca.DeleteFromList(i);
        //voca.WriteToFile();
        DisplayElement();     
    }

    void ClearDisPlayElement()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
