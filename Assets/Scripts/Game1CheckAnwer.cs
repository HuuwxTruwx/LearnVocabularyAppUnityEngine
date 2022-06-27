using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Game1CheckAnwer : AnswerScripts
{
    public GameObject answer;
    public Text scoreText;
    int score;
    public Score totalScore;
    public GameObject notice;
    public Text noticeText;
    public Text scoreInNotice;
    Button button;
    public DinoController dino;
    public GameObject correctNotice;

   
    void Start()
    {
        //notice.SetActive(false);
        CreateAnswerList();
        DisPlayAnswer();
    }

    private void Update()
    {
        if (dino.die)
        {
            string result = vocaController.GetValue(question.Question.text);
            DisplayNotice(false, result);
        }
    }

    IEnumerator FadeCorrectNotice()
    {
        correctNotice.SetActive(true);
        correctNotice.transform.DOScale(1, 0.5f).SetEase(Ease.OutQuart);
        yield return new WaitForSeconds(1);
        correctNotice.SetActive(false);
        correctNotice.transform.localScale = Vector3.zero;
    }
    public void DisPlayAnswer()
    {
        ClearDisPlayElement();
        GetListAnswer(4);
        GameObject temp;
        for (int i = 0; i < 4; i++)
        {
            temp = Instantiate(answer, transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = SelectAswer();
            button = temp.GetComponent<Button>();
            button.AddEventListener(i, OnFoderBtnClicked);
        }
        answerIndex.Clear();
    }
    void ClearDisPlayElement()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void OnFoderBtnClicked(int index)
    {
        string temp = transform.GetChild(index).GetChild(0).GetComponent<Text>().text;
        ChooseAnswer(temp);
    }

    void ChooseAnswer(string answer)
    {
        string result = vocaController.GetValue(question.Question.text);
        if (result == answer)
        {
            score += 1;
            vocaController.UpdateKnowByValue(answer,1);
            StartCoroutine(FadeCorrectNotice());
            dino.jump = true;
            scoreText.text = score.ToString();
            if (!question.HaveQuestion())
            {
                dino.SetAnimationState();
                //notice.SetActive(true);
                notice.transform.DOLocalMoveX(-3, 0.5f).SetEase(Ease.OutQuint);
                totalScore.score += score;
                DisplayNotice(true, "Completed");
                PlayFabManager.instance.SaveVoca();
                PlayFabManager.instance.SaveTotalScore();
                PlayFabManager.instance.SendLeaderboard(totalScore.score);
            }

           
        }
        else
        {
            vocaController.UpdateKnowByValue(answer, -1);
            DisplayNotice(false, result);
            PlayFabManager.instance.SaveVoca();
        }
    }

    void DisplayNotice(bool correct, string message)
    {
        //notice.SetActive(true);
        notice.transform.DOLocalMoveX(-3, 0.5f).SetEase(Ease.OutQuint);
        if (!correct)
        {
            string temp = question.Question.text + " : " + message;
            noticeText.text = temp;
            scoreInNotice.text = "Score : " + score;
        }
        else
        {
            noticeText.text = message;
            scoreInNotice.text = "Score : " + score;
        }

    }
}
