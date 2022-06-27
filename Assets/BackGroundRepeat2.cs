using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRepeat2 : MonoBehaviour
{
    
    public float speed;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -0.1f, 0) * speed;
        if (transform.position.y < -96)
        {
            transform.position = startPos;
        }
    }
}
