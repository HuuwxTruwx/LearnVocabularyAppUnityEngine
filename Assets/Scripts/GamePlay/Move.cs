﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    
    
  
    private void Update()
    {
        transform.position += new Vector3(0, -0.5f, 0) * speed;
        
    }
}

