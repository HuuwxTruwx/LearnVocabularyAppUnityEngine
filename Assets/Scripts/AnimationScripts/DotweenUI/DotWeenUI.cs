using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DotWeenUI : MonoBehaviour
{
    public Image hiImage;
    public GameObject email;
    public GameObject user;
    public GameObject password;
    public GameObject signIn;
    public GameObject signUP;
    public float PosX;
    // Start is called before the first frame update
    void Start()
    {
        hiImage.rectTransform.DOScale(1.3f,1.2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutQuad);
        email.transform.DOLocalMoveX(PosX, 1,true).SetEase(Ease.OutSine);
        user.transform.DOLocalMoveX(PosX, 1.1f,true).SetEase(Ease.OutSine);
        password.transform.DOLocalMoveX(PosX, 1.2f,true).SetEase(Ease.OutSine);
        signIn.transform.DOLocalMoveX(PosX, 1f, true).SetEase(Ease.OutSine);
        signUP.transform.DOLocalMoveX(PosX, 1.2f, true).SetEase(Ease.OutSine);
    }

   
}
