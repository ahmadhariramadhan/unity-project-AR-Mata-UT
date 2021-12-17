using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionQuizObj : MonoBehaviour
{
    [SerializeField]
    private Text descText;
    public QuizComponent.componentQuiz componentQuiz;


    public void InitObj(QuizComponent.componentQuiz _componentQuiz) {
        componentQuiz = _componentQuiz;
        descText.text = _componentQuiz.description;
    }
}
