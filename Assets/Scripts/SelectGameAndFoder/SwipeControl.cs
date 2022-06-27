using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControl : MonoBehaviour
{
    public GameObject scrollBar;
    public float scrollPos = 0;
    public float[] pos;
    float distance;
    int itemIndex = 0;
   
    void Start()
    {
        //SetPosElement(transform.childCount);
        //SetPosition();
    }

  
    void Update()
    {
      
        //MoveSwipe();
    }

    public void MoveSwipe()
    {
        scrollPos = scrollBar.GetComponent<Scrollbar>().value;
        if (!Input.GetMouseButton(0) || Input.touchCount < 0)
        {
            for (int i = 0; i < pos.Length; i++)
            {
                TranslateScrollBar(i);
            }
        }
    }
    public void SetPosElement(int number)
    {
        pos = new float[number];
    }
    
    public void SetPosition()
    {
        distance = 1f / (pos.Length - 1);    
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    public void TranslateScrollBar(int  i)
    {     
        float left = pos[i] - (distance / 2);
        float right = pos[i] + (distance / 2);
        if(scrollPos < right && scrollPos > left)
        {
            scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollPos, pos[i], 0.5f);
            SetScale(i);
            itemIndex = i;         
        }
    }

    public void SetScale(int i)
    {
        transform.GetChild(i).localScale = Vector3.Lerp(transform.GetChild(i).localScale, new Vector3(1f, 1f,1f), 0.1f );
        for(int j = 0; j < pos.Length; j++)
        {
            if(j != i)
            {
                transform.GetChild(j).localScale = Vector3.Lerp(transform.GetChild(j).localScale, new Vector3(0.7f, 0.7f,1f), 0.1f );
            }
        }
    }

    public string GetGame()
    {
        string temp = transform.GetChild(itemIndex).GetChild(0).GetComponent<Text>().text;
        return temp;
    }
}
