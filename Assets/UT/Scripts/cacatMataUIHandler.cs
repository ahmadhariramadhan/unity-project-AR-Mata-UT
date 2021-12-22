using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cacatMataUIHandler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> models = new List<GameObject>();

    private void OnEnable() {
        ChangeModel(0);
    }

    public void ChangeModel(int _index){
        ResetModels();
        models[_index].SetActive(true);
    }

    private void ResetModels(){
        for (int i = 0; i < models.Count; i++)
        {
            models[i].SetActive(false);
        }
    }
}
