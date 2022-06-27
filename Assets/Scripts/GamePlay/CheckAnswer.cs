using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CheckAnswer : MonoBehaviour
{
    public VocaScriptAble vocaScriptAble;
    public VocaController vocaController;
   
    public Score totalScore;
    public Text noticeText;
    public Text socreInNotice;
    public Text scoreText;
    public int score;
    public GameObject notice;
    //public Voca vocabulary;
    public QuestionScript question;
    AnswerScripts answerScripts;
    public GameObject practical;
    // Start is called before the first frame update
    private void Start()
    {
        //notice.SetActive(false);
        score = 0;
        question = GameObject.Find("Question").GetComponent<QuestionScript>();
        answerScripts = GameObject.Find("ANSWER").GetComponent<AnswerScripts>();
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(practical, transform.position+ Vector3.up*10,Quaternion.identity );
        ChooseAnswer(collision.gameObject.GetComponent<TextMesh>().text); 
        Destroy(collision.transform.parent.gameObject);
      
    }

    void ChooseAnswer(string answer)
    {
        string result = vocaController.GetValue(question.Question.text);
        if (result == answer)
        {
            score += 1;
            vocaController.UpdateKnowByValue(answer, 1);
            scoreText.text = score.ToString();
            if (question.HaveQuestion())
            {              
                         
                question.SelectQuestion();
                answerScripts.InstanceAnswer();
            }
            else
            {
               //notice.SetActive(true);
                notice.transform.DOLocalMoveX(0, 0.5f).SetEase(Ease.OutQuint);
                totalScore.score += score;
                socreInNotice.text = "Score : " + score;
                noticeText.text = "Complete";                          
                PlayFabManager.instance.SaveTotalScore();
                PlayFabManager.instance.SendLeaderboard(totalScore.score);

            }
           
        }
        else
        {
            vocaController.UpdateKnowByValue(answer, -1);
            //notice.SetActive(true);
            string temp = question.Question.text + " : " + result;
            noticeText.text = temp;
            socreInNotice.text = "Score : " + score;
            notice.transform.DOLocalMoveX(0, 0.5f).SetEase(Ease.OutQuint);
           
            //totalScore.score += score;
            //PlayFabManager.instance.SaveTotalScore();
            //PlayFabManager.instance.SendLeaderboard(totalScore.score);
                  
        }
            
    }
}
