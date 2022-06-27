using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DWrotate : MonoBehaviour
{

    public float speed;

    private void Awake()
    {
        transform.DOScale(1, 1);
        transform.DOLocalRotate(new Vector3(0, 0, -360), speed, RotateMode.Fast).SetLoops(-1, LoopType.Restart).SetRelative();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
