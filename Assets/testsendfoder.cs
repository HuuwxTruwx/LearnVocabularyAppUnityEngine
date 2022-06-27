using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsendfoder : MonoBehaviour
{
   public void test()
    {
        PlayFabManager.instance.SaveFoder();
    }

    public void testGet()
    {
        PlayFabManager.instance.GetFoder();
    }

    public void testSaveVoca()
    {
        PlayFabManager.instance.SaveVoca();
    }
    public void testGetVoca()
    {
        PlayFabManager.instance.GetVoca();
    }
}
