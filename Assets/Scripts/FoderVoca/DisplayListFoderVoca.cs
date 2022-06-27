using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayListFoderVoca : MonoBehaviour
{
    public GameObject comfrimDelete;
    public VocaController vocaController;
    public ListFoderVocabulary listFoderVocabulary;
    public FoderScriptAble foderScriptable;
    public GameObject foder;
    Button button;
    Button deleteButton;

    bool confirm = false;
   
    public OnFoder onFoder;

    public Voca voca;
    void Start()
    {
        //PlayFabManager.instance.GetFoder();
        LoadForder();
    }


    public void LoadForder()
    {
        //listFoderVocabulary.SetPath();
        //listFoderVocabulary.CreateFilePath();
        //listFoderVocabulary.LoadFile();
        ClearDisplayFoder();
        GameObject temp;
        for (int i = 0; i < foderScriptable.foderList.Count; i++)
        {
            temp = Instantiate(foder, transform);
            temp.transform.GetChild(2).GetComponent<Text>().text = foderScriptable.foderList[i].name;
            button = temp.GetComponent<Button>();
            deleteButton = temp.transform.GetChild(0).GetComponent<Button>();
            button.AddEventListener(i, OnFoderBtnClicked);
            deleteButton.AddEventListener(i, ClickDeleteFoder);
        }
    }
    void OnFoderBtnClicked(int itemIndex)
    {
        string name = foderScriptable.foderList[itemIndex].name;
        onFoder.onFoderName = name;
        vocaController.LoadVocaInFoder();
        //voca.SetPath(name);
        //voca.LoadFile();
        ManagerScene.instance.ChangeToScene("Vocabulary");
    }

    void ClearDisplayFoder()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ClickDeleteFoder(int i)
    {
        comfrimDelete.SetActive(true);   
        Button comfirm = comfrimDelete.transform.GetChild(0).GetComponent<Button>();
        if(confirm)
        {
            //voca.DeleteFile(foderScriptable.foderList[i].name);
            string foder = foderScriptable.foderList[i].name;
            vocaController.DeleteVocaInFoder(foder);
            foderScriptable.foderList.Remove(foderScriptable.foderList[i]);
            PlayFabManager.instance.SaveVoca();
            PlayFabManager.instance.SaveFoder();

            //listFoderVocabulary.DeleteFoder(i);
            //listFoderVocabulary.WriteToFile();    
            LoadForder();
        }
        confirm = false;
  
    }

    public  void ConfimDelete()
    {
        confirm = true;
    }
}
