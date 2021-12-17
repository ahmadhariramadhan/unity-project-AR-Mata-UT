using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField inputField;
    public GameObject confirmPanel;
    public Text result;
    UserData userdata;
    string inputFieldText;
    StaticData staticData;

    // Start is called before the first frame update
    void Start()
    {
        userdata = new UserData();
        userdata.userName = "";
        userdata.pretestScore = 0;
        userdata.postTestScore = 0;

        confirmPanel.SetActive(false);
    }

    public string GetUserInput()
    {
       return inputField.text;
    }

    public void ToggleConfirmationPanel(bool _state)
    {
        confirmPanel.SetActive(_state);
        result.text = GetUserInput();
        SaveUserData();
    }

    public void SaveUserData()
    {
        userdata.userName = GetUserInput();
        StaticData.username = userdata.userName;
        userdata.pretestScore = StaticData.scorePre;
        userdata.postTestScore = StaticData.scorePost;
    }

    public void SaveUserScore()
    {
    }

    public void SaveUserScorePost()
    {
    }
}
