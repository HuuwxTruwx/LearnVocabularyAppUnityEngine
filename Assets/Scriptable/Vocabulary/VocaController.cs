using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VocaController : MonoBehaviour
{
    public VocaScriptAble vocaScriptAble;
    public OnFoder onFoder;

    private void Start()
    {
        SortVocaWithKnow();
    }

    public void LoadVocaInFoder()
    {
        List<Vocabulary> vocaListView = new List<Vocabulary>();
        foreach (var item in vocaScriptAble.vocabularyList)
        {
            if (item.foderName == onFoder.onFoderName)
            {
                vocaListView.Add(item);
            }
        }
        vocaScriptAble.vocabularyDisplay = vocaListView;

    }
    public void SortVocaWithKnow()
    {
        vocaScriptAble.vocabularyDisplay.Sort((v1,v2) => v1.know.CompareTo(v2.know));   
    }

    public string GetValue(string key) 
    {
        Vocabulary v = vocaScriptAble.vocabularyDisplay.Find(x => x.english == key);
        return v.vietnam;
    }

    public void UpdateKnowByValue(string vietnam ,int value)
    {
        for (int i = 0; i < vocaScriptAble.vocabularyList.Count; i++)
        {
            if (vocaScriptAble.vocabularyDisplay[i].vietnam == vietnam)
            {
                vocaScriptAble.vocabularyList[i].know += value;
            }
        }
    }

   
    public int GetIndexValue(string key)
    {
        for(int i = 0; i < vocaScriptAble.vocabularyDisplay.Count; i++)
        {
            if(vocaScriptAble.vocabularyDisplay[i].english == key)
            {
                return i;
            }
        }
        return 0;
    }
   
    public void DeleteVocaInFoder(string foder)
    {
       for(int i=0; i < vocaScriptAble.vocabularyList.Count; i++)
        {
            if(vocaScriptAble.vocabularyList[i].foderName == foder)
            {
                vocaScriptAble.vocabularyList.RemoveAt(i);
            }
        }

    }
}
