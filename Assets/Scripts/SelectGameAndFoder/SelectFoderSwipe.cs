using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectFoderSwipe : SwipeControl
{
    public OnFoder onFoder;
    public FoderScriptAble foderScriptAble;
    //public ListFoderVocabulary listFoder;
    public GameObject fodePrefab;
    //public Voca voca;
    Button button;
   
    // Start is called before the first frame update
    void Start()
    {
        //listFoder.SetPath();
        //listFoder.LoadFile();
        //SetPosElement(listFoder.listFoder.Count);
        SetPosElement(foderScriptAble.foderList.Count);
        GameObject temp;
        for (int i = 0; i < pos.Length; i++)
        {
            temp = Instantiate(fodePrefab, transform);
            //temp.transform.GetChild(0).GetComponent<Text>().text = listFoder.listFoder[i];
            temp.transform.GetChild(0).GetComponent<Text>().text = foderScriptAble.foderList[i].name;
            button = temp.GetComponent<Button>();
            button.AddEventListener(i, OnFoderBtnClicked);
        }
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSwipe();
        //scrollPos = scrollBar.GetComponent<Scrollbar>().value;
        //if (!Input.GetMouseButton(0) || Input.touchCount < 0)
        //{
        //    for (int i = 0; i < pos.Length; i++)
        //    {
        //        TranslateScrollBar(i);
        //    }
        //}
    }

    public void LoadVocabulary()
    {
        string listVoca = GetGame();
        onFoder.onFoderName = listVoca;
        //voca.SetPath(listVoca);
        //voca.LoadFile();
        //Debug.Log("Load file Finish");
    }

    public void OnFoderBtnClicked(int itemIndex)
    {     
        ManagerScene.instance.ChangeToScene("Foder");
    }
    

}
