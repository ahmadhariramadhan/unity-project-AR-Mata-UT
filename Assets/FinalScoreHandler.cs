using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreHandler : MonoBehaviour
{
    public Text userName;
    //public Text scorePretest;
    //public Text scorePosttest;

    private void OnEnable()
    {
        userName.text = string.Format ("Nama : {0}\nNilai pre-test: {1}\nNilai post-test: {2}\n", StaticData.username, StaticData.scorePre, StaticData.scorePost);
    }
}
