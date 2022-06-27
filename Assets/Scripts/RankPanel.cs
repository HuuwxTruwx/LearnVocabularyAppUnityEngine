using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RankPanel : MonoBehaviour
{

    public DIsplayRank displayRank;

    void Start()
    {
        this.gameObject.SetActive(false);
    }


    public void StartCourotineGetRank()
    {
        StartCoroutine(GetRandAndDisplay());
    }
    IEnumerator GetRandAndDisplay()
    {
        GetRank();
        yield return new WaitForSeconds(1f);
        displayRank.InstanceRankElement();
    }
    public void GetRank()
    {
        PlayFabManager.instance.GetLeaderboard();
        
    }

   
    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
    
    public void DisPlayPanel()
    {
        gameObject.SetActive(true);
    }
}
