using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreHandler : MonoBehaviour
{
    public Text userName;
    [SerializeField]
    private Image taskBagianMata;
    [SerializeField]
    private Image taskProsesMata;
    [SerializeField]
    private Image taskRabunJauh;
    [SerializeField]
    private Image taskRabunDekat;

    //public Text scorePretest;
    //public Text scorePosttest;

    private void OnEnable()
    {
        userName.text = string.Format ("Nama : {0}\nNilai pre-test: {1}\nNilai post-test: {2}\n", StaticData.username, StaticData.scorePre, StaticData.scorePost);
        CheckTask();
    }

    private void CheckTask(){
        if (StaticData.doneTaskBagianMata==true)
        {
            taskBagianMata.color = Color.green;
        }else if (StaticData.doneTaskProsesMata==true)
        {
            taskBagianMata.color = Color.green;
        }else if (StaticData.doneTaskRabunDekat==true)
        {
            taskBagianMata.color = Color.green;
        }else if (StaticData.doneTaskRabunJauh==true)
        {
            taskBagianMata.color = Color.green;
        }
    }
}
