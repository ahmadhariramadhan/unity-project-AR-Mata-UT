using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "QuizData" , menuName="Quiz")]
public class QuizComponent : ScriptableObject
{

    public string id;
    public int scoreMax;
    public List<componentQuiz> ComponentQuiz = new List<componentQuiz>();
    [Serializable]
    public class componentQuiz {
        public int score;
        public Texture imageQuiz;
        [TextArea]
        public string description;
        public List<choiceComponent> choiceComponents = new List<choiceComponent>();
    }

    [Serializable]
    public class choiceComponent {
        public string descChoice;
        public bool correctAnswer;
    }
}
