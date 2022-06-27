using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    public VocaScriptAble vocaScriptAble;
    public VocaController vocaController;
    
    public Text Question;
    public  int _index = 0;
   

    // Start is called before the first frame update
    private void Awake()
    {

    }
    private void Start()
    {
        vocaController.SortVocaWithKnow();
        //SelectQuestion();
    }
    public void SelectQuestion()
    {
        if(vocaScriptAble.vocabularyDisplay != null)
        {          
            Question.text = vocaScriptAble.vocabularyDisplay[_index].english;
            TTS.instance.Play(Question.text);
            _index++;
        }
      
    }

    

    public bool HaveQuestion()
    {
        if (vocaScriptAble.vocabularyDisplay.Count == _index)
        {
            return false;
        }
        return true;
    }
}
