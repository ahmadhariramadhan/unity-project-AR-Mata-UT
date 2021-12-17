using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

public class QuizHandler : MonoBehaviour
{
    public static QuizHandler Instance;
    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField]
    private bool randomQuest;
    [SerializeField]
    private GameObject panelTutor;
    public QuizComponent quizComponent;
    public QuizComponent ranDomQuizComponent;
    public List<QuizComponent.componentQuiz> randomQuizComponent = new List<QuizComponent.componentQuiz>();
    public ObjectPool butttonAnswerObj;
    public Transform pivotButtonAnswer;
    public GameObject panelQuiz;
    public GameObject panelScore;
    public Text scoreText;
    public RawImage imageQuiz;
    public Text quizNumber;
    public Text quizDesc;
    public int currentQuestIndex;
    public int currentScore = 0;
    public QuizComponent.componentQuiz currentComponentQuiz;
    public List<AnswerObj> listAnswerObj = new List<AnswerObj>();
    public List<int> takeList = new List<int>();
    private int lastValue;
    private int randomNumber;
    

    private void Start() {
        takeList = new List<int>(new int[quizComponent.ComponentQuiz.Count]);
        ranDomQuizComponent.ComponentQuiz.Clear();
        InitPanelTutor();
    }

    public void InitPanelTutor(){
        panelTutor.SetActive(true);
        panelQuiz.SetActive(false);
    }

    public void InitQuiz() {
        panelQuiz.SetActive(true);
        if (randomQuest!=true)
        {
            if (quizComponent.ComponentQuiz.Count > 0) {
            panelTutor.SetActive(false);
            panelScore.SetActive(false);
            SetQuestion(0);
            }
        }
        else
        {
            for (int i = 0; i < quizComponent.ComponentQuiz.Count; i++)
            {
                randomNumber = Random.Range(1,(quizComponent.ComponentQuiz.Count)+1);
                while (takeList.Contains(randomNumber))
                {
                      randomNumber = Random.Range(1,(quizComponent.ComponentQuiz.Count)+1);
                }
                takeList[i] = randomNumber;
                ranDomQuizComponent.ComponentQuiz.Add(quizComponent.ComponentQuiz[takeList[i]-1]);
                // randomQuizComponent.Add(quizComponent.ComponentQuiz[takeList[i]-1]);
                print(randomNumber);
            }
            if (ranDomQuizComponent.ComponentQuiz.Count > 0) {
            panelTutor.SetActive(false);
            panelScore.SetActive(false);
            SetQuestion(0);
            }
            

        }  
        
    }

    private void SetQuestion(int index) {
        currentQuestIndex = index;
        if (randomQuest==true)
        {
            currentComponentQuiz = ranDomQuizComponent.ComponentQuiz[currentQuestIndex];
            quizDesc.text = ranDomQuizComponent.ComponentQuiz[index].description;
        }else{
            currentComponentQuiz = quizComponent.ComponentQuiz[currentQuestIndex];
            quizDesc.text = quizComponent.ComponentQuiz[index].description;
        }
        
        int number = index+1;
        quizNumber.text = string.Format(number.ToString()+".");
        
        SetImageQuiz(index);
        SetAnswer();
    }

    private void SetImageQuiz(int index) {
        if (quizComponent.ComponentQuiz[index].imageQuiz!=null) {
            imageQuiz.enabled = true;
            imageQuiz.texture = quizComponent.ComponentQuiz[index].imageQuiz;
        } else {
            imageQuiz.enabled = false;
        }
    }

    private void SetAnswer() {
        for (int j = 0; j < currentComponentQuiz.choiceComponents.Count; j++) {
            GameObject g = butttonAnswerObj.GetObjectFromPool();
            AnswerObj currentAnswerObj = g.GetComponent<AnswerObj>();
            int questionIndex = j;
            g.transform.SetParent(pivotButtonAnswer);
            listAnswerObj.Add(currentAnswerObj);
            g.transform.localScale = Vector3.one;
            g.transform.localPosition = Vector3.zero;
            g.transform.localRotation = Quaternion.identity;
            g.transform.SetAsLastSibling();
            currentAnswerObj.InitObj(currentComponentQuiz, currentComponentQuiz.choiceComponents[j], questionIndex, SelectAnswer);
        }
        
    }

    public void ResetAnswers() {
        //AnswerObj[] answerObjects = pivotButtonAnswer.GetComponentsInChildren<AnswerObj>();
        //for (int i = 0; i < answerObjects.Length; i++) {
        //    butttonAnswerObj.AddObjectToPool(answerObjects[i].gameObject);
        //}
        for (int i = 0; i < listAnswerObj.Count; i++) {
            listAnswerObj[i].gameObject.SetActive(false);
        }
    }

    private void SelectAnswer(int index) {
        if (currentQuestIndex < quizComponent.ComponentQuiz.Count-1) {
            int nextIndex = currentQuestIndex + 1;
            print(currentComponentQuiz.choiceComponents[0].correctAnswer);
            ResetAnswers();
            SetQuestion(nextIndex);
        } else {
            StartCoroutine(Done());
            print("Selesai");
        }
    }

    private IEnumerator Done() {
        yield return null;
        panelQuiz.SetActive(false);
        panelScore.SetActive(true);
        scoreText.text = currentScore.ToString();
    }

    public void OpenQuizRandom(){
        randomQuest=true;
        currentScore = 0;
        InitPanelTutor();
    }

    //CUSTOM
    public MainMenuComponent finalScorePage;
    public void SubmitPanelScore() {
        if (StaticData.isDonePre == false)
        {
            StaticData.scorePre = currentScore;
            currentScore = 0;
            currentQuestIndex = 0;
            MainMenuManager.Instance.ContinueCor();
            StaticData.isDonePre = true;
        }
        else
        {
            StaticData.scorePost = currentScore;
            currentScore = 0;
            currentQuestIndex = 0;
            MainMenuManager.Instance.JumpToPage(finalScorePage);
        }
        panelScore.SetActive(false);
        ResetAnswers();
        // panelQuiz.SetActive(true);
        // InitQuiz();
    }

}
