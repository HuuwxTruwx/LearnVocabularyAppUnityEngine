using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRePeat : MonoBehaviour
{
    public float x = -0.1f;
  
    public float speed;
    Vector3 startPos;
    DinoController dino;
    private void Start()
    {
        dino = GameObject.Find("Dino").GetComponent<DinoController>();
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (!dino.die)
        {
            transform.position += new Vector3(x, 0, 0) * speed;
            if (transform.position.x < -14.8)
            {
                transform.position = startPos;
            }
        }
       

    }
}
