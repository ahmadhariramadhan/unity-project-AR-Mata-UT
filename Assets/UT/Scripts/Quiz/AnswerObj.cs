using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnswerObj : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Text answerText;
    public QuizComponent.componentQuiz componentQuiz;
    public QuizComponent.choiceComponent answerComponent;


    public void InitObj(QuizComponent.componentQuiz _componentQuiz, QuizComponent.choiceComponent _answerComponent,int _index , Action<int> _selectEvent) {
        componentQuiz = _componentQuiz;
        answerComponent = _answerComponent;
        answerText.text = _answerComponent.descChoice;
        button.onClick.AddListener(delegate { _selectEvent(_index); SelectAnswer(); });
    }

    public void SelectAnswer() {
        if (answerComponent.correctAnswer==true) {
            if (StaticData.isDonePre == false)
            {
                StaticData.scorePre += componentQuiz.score;
                QuizHandler.Instance.currentScore = StaticData.scorePre;
            }
            else
            {
                StaticData.scorePost += componentQuiz.score;
                QuizHandler.Instance.currentScore = StaticData.scorePost;
            }
            SoundFX.Instance.PlaySound(1);
            print("Jawaban Benar");
        } else {
            print("Jawaban Salah");
            SoundFX.Instance.PlaySound(2);
        }
        //QuizHandler.Instance.currentScore = StaticData.scorePre;
        print(QuizHandler.Instance.currentScore.ToString());
    }
}
