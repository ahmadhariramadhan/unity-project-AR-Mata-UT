using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class QuizResult 
{
    public string id;
    public int score;
    public List<answer> listAnswer = new List<answer>();
    [Serializable]
    public class answer {
        public string answerText;
        public int scorePerQuest;
    }
}
