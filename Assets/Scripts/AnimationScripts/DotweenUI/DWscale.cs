using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DWscale : MonoBehaviour
{
    public float scale;
    public float time;
    public int loop;

    private void Awake()
    {
        gameObject.transform.DOScale(scale, time).SetEase(Ease.OutSine).SetLoops(loop, LoopType.Yoyo);

    }
    

}
