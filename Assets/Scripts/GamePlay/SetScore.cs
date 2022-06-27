using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    public Score score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(SetTotalScore());
    }
   
    IEnumerator SetTotalScore()
    {
        PlayFabManager.instance.GetTotalScore();
        yield return new WaitForSeconds(2);
        scoreText.text = "Score : " + score.score;
        
    }
    
}
