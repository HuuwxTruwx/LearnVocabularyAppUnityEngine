using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoderScriptable")]
public class FoderScriptAble : ScriptableObject
{
    public List<Foder> foderList = new List<Foder>();
}

public class Foder
{
 
    public string name;
    public Foder( string name)
    {
        
        this.name = name;
    }
}
