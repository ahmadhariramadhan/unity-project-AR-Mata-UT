using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePartHandler : MonoBehaviour
{
    [SerializeField]
    private List<EyePart> eyePartList = new List<EyePart>();

    public static EyePartHandler Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }
    public void ResetButtonEyePart(){
        for (int i = 0; i < eyePartList.Count; i++)
        {
            eyePartList[i].ResetBtnPopUp();
        }
    }


}
