using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnswerScripts : MonoBehaviour
{
    public VocaScriptAble vocaScriptAble;
    public VocaController vocaController;
    public GameObject AnswerBox;
    //public Voca vocabulary;
    //index Value in Vocabulaty
    public List<int> answerIndex = new List<int>();
    //use to pick non repeat answerIndex
    public List<int> listAnswer = new List<int>();
    public QuestionScript question;
    public int _index;

    // Start is called before the first frame update
    void Start()
    {
        CreateAnswerList();
        InstanceAnswer();
    }

    public void CreateAnswerList()
    {
        listAnswer.Clear();
        for (int i = 0; i < vocaScriptAble.vocabularyDisplay.Count; i++)
        {
            listAnswer.Add(i);
        }
    }
    public void InstanceAnswer()
    {
        GetListAnswer(3);
        AnswerBox.transform.GetChild(0).GetComponent<TextMesh>().text = SelectAswer();
        Instantiate(AnswerBox, transform.position + new Vector3(0, 50, 0), Quaternion.identity);
        AnswerBox.transform.GetChild(0).GetComponent<TextMesh>().text = SelectAswer();
        Instantiate(AnswerBox, transform.position + Vector3.left * 15 + new Vector3(0, 50, 0), Quaternion.identity);
        AnswerBox.transform.GetChild(0).GetComponent<TextMesh>().text = SelectAswer();
        Instantiate(AnswerBox, transform.position + Vector3.right * 15 + new Vector3(0, 50, 0), Quaternion.identity);
        answerIndex.Clear();
    }

    public string SelectAswer()
    {
        _index = RanDomIndex(ref answerIndex);
        answerIndex.Remove(_index);
        return vocaScriptAble.vocabularyDisplay[_index].vietnam;
    }

    public int RanDomIndex(ref List<int> a)
    {
        int i = Random.Range(0, a.Count);
        return a[i];
    }

    public void GetListAnswer(int numberAnswer)
    {
        CreateAnswerList();
        question = GameObject.Find("Question").GetComponent<QuestionScript>();
        int result = vocaController.GetIndexValue(question.Question.text);
        answerIndex.Add(result);
        listAnswer.Remove(listAnswer[result]);
        int i = RanDomIndex(ref listAnswer);
        answerIndex.Add(i);
        listAnswer.Remove(i);
        int j = RanDomIndex(ref listAnswer);
        answerIndex.Add(j);
        listAnswer.Remove(j);
        if(numberAnswer == 4)
        {
            int k = RanDomIndex(ref listAnswer);
            answerIndex.Add(k);
        }
       
    }

}
