using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class AddFoderPanel : MonoBehaviour
{
    public GameObject addFoder;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        addFoder.transform.DOLocalMoveX(1215,time).SetEase(Ease.OutQuad);
    }

    public void DisPlay()
    {
        gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
        addFoder.transform.DOLocalMoveX(0, time).SetEase(Ease.OutQuad);

    }

    public void Hide()
    {   
        addFoder.transform.DOLocalMoveX(1215, time).SetEase(Ease.OutQuad);
        transform.GetChild(0).gameObject.SetActive(false);    
    }
}
