using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DIsplayRank : MonoBehaviour
{
    public Leaderboard leaderboard;
    public GameObject element;
    // Start is called before the first frame update
   
    public void InstanceRankElement()
    {
        ClearDisplayFoder();
        GameObject temp;
        foreach (var item in leaderboard.Players)
        {
            temp = Instantiate(element,transform);
            temp.transform.GetChild(1).GetComponent<Text>().text = "Player : " + item.id;
            temp.transform.GetChild(2).GetComponent<Text>().text = item.rank;
            temp.transform.GetChild(3).GetComponent<Text>().text = "Total Score : " +item.totalScore;
        }
    }

    void ClearDisplayFoder()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
