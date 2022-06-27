using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FlashCard : MonoBehaviour
{
    public VocaScriptAble vocaScriptAble;
    public Voca voca;
    public Text text;
    bool flip;
    public int vocaIndex = 0;
   


    private void Start()
    {
       
        //text.text = voca.Vocabularys.ElementAt(vocaIndex).Key;
        text.text = vocaScriptAble.vocabularyDisplay[vocaIndex].english;
    }
    public void Onclick ()
    {
        if (flip)
        {
          
            //text.text = voca.Vocabularys.ElementAt(vocaIndex).Key;
            text.text = vocaScriptAble.vocabularyDisplay[vocaIndex].english;
            flip = false;
        }
        else
        {
         
            //text.text = voca.Vocabularys.ElementAt(vocaIndex).Value;
            text.text = vocaScriptAble.vocabularyDisplay[vocaIndex].vietnam;
            flip = true;
        }
        Debug.Log("flip");
    }

    public void Next()
    {
        if (vocaIndex < vocaScriptAble.vocabularyDisplay.Count-1)
        {
            StartCoroutine(Scale());
            vocaIndex++;
            flip = false;
            text.text = vocaScriptAble.vocabularyDisplay[vocaIndex].english;
            Debug.Log("next");
        }
        
    }
    IEnumerator Scale()
    {
        gameObject.transform.DOScale(0.1f,0.5f).SetLoops(1,LoopType.Yoyo).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.DOScale(1, 0.5f).SetLoops(1, LoopType.Yoyo).SetEase(Ease.OutCubic);
    }
   
    public void Back()
    {
        if (vocaIndex > 0)
        {
            StartCoroutine(Scale());
            vocaIndex--;
            flip = false;
            //text.text = voca.Vocabularys.ElementAt(vocaIndex).Key;
            text.text = vocaScriptAble.vocabularyDisplay[vocaIndex].english;
            Debug.Log("back");
        }               
    }
}
