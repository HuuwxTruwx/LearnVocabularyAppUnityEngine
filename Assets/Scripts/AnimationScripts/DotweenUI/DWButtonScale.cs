using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DWButtonScale : MonoBehaviour
{
    public float scale = 1f;
    public float duration;

   
    public void  Animation()
    {
       transform.DOScale(scale, duration).SetLoops(2,LoopType.Yoyo).SetEase(Ease.OutCirc);
       
    }
}
