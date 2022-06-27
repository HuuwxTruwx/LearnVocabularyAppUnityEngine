using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VocabularyScriptable")]
public class VocaScriptAble : ScriptableObject
{
    public List<Vocabulary> vocabularyList = new List<Vocabulary>();
    public List<Vocabulary> vocabularyDisplay = new List<Vocabulary>();
}

public class Vocabulary
{
    public string foderName;
    public string english;
    public string vietnam;
    public int know;
    public Vocabulary(string foderName, string english, string vietnam, int know)
    {
        this.foderName = foderName;
        this.english = english;
        this.vietnam = vietnam;
        this.know = know;
    }
}
