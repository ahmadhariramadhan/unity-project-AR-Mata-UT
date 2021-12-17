using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizNewHandler : MonoBehaviour
{
    public List<answerObj> answerObjs = new List<answerObj>();
    public GameObject[] showQuizObj;
    [SerializeField]
    private int currentIndex;
    [SerializeField]
    private GameObject objTrue;
    [SerializeField]
    private GameObject objFalse;
    [SerializeField]
    private GameObject buttonSubmit;
    [SerializeField]
    private GameObject buttonReplay;
    [SerializeField]
    private GameObject panelBlockAnswer;

    [System.Serializable]
    public class answerObj{
        public string nameAnswer;
        public bool answer;
    }

    public void CheckAnswer(int _index) {
        ResetObj();
        currentIndex = _index;
        showQuizObj[_index].SetActive(true);
    }

    public void SubmitAnswer() {
        ResetObj();
        panelBlockAnswer.SetActive(true);
        if (answerObjs[currentIndex].answer==true) {
            objTrue.SetActive(true);
            objFalse.SetActive(false);
        } else {
            objTrue.SetActive(false);
            objFalse.SetActive(true);
        }
        buttonSubmit.SetActive(false);
        buttonReplay.SetActive(true);
    }

    public void Replay() {
        ResetObj();
        panelBlockAnswer.SetActive(false);
        objTrue.SetActive(false);
        objFalse.SetActive(false);
        buttonReplay.SetActive(false);
        buttonSubmit.SetActive(true);
    }

    private void ResetObj() {
        for (int i = 0; i < showQuizObj.Length; i++) {
            showQuizObj[i].SetActive(false);
        }
    }
}
