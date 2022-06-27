using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameSwipe : SwipeControl
{

    // Start is called before the first frame update
    void Start()
    {
        SetPosElement(5);
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSwipe();
    }

    public void SelectGame()
    {
        string game = GetGame();
        
        ManagerScene.instance.ChangeToScene(game);
    }
}
