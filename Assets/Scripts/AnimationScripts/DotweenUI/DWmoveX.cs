using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DWmoveX : MonoBehaviour
{
    public float posX;
    public float time;
    void Start()
    {
       gameObject.transform.DOLocalMoveX(posX,time).SetEase(Ease.OutCubic);
    }

    
}
