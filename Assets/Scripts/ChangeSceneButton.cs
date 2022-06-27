using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{
    public void ClickChangeScene(string scene)
    {
        ManagerScene.instance.ChangeToScene(scene);
    }
}
