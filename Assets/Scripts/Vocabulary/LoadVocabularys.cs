using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVocabularys : MonoBehaviour
{
    public Voca voca;
    // Start is called before the first frame update
    void Start()
    {
        voca.LoadFile();     
    }
}
