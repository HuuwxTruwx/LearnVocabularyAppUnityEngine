using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFoder : MonoBehaviour
{
    public FoderScriptAble foderScriptAble; 
    public Voca voca;
    public ListFoderVocabulary listFoder;
    public InputField foderName;
    public DisplayListFoderVoca displayListFoder;
    // Start is called before the first frame update
    void Start()
    {
      
        //PlayFabManager.instance.SaveFoder();
        //PlayFabManager.instance.GetFoder();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    public void ClickAddFoder()
    {
        //voca.SetPath(foderName.text);
        //voca.CreateFilePath();
        //listFoder.listFoder.Add(foderName.text);
        //listFoder.WriteToFile();
        Foder foder = new Foder(foderName.text);
        foderScriptAble.foderList.Add(foder);
        PlayFabManager.instance.SaveFoder();
        displayListFoder.LoadForder();
        foderName.text = "";
    }
}
