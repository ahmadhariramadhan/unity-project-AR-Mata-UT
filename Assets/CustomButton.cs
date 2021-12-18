using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public Image iconBtnBagianMata;
    public Image iconBtnProsesMata;
    public Image iconBtnRabunJauh;
    public Image iconRabunDekat;
    public Image iconCpuMk;
    
    private void OnEnable()
    {
        if (StaticData.doneTaskBagianMata==true)
        {
            iconBtnBagianMata.color = Color.green;
        }
        if (StaticData.doneTaskProsesMata==true)
        {
            iconBtnProsesMata.color = Color.green;
        }
        if (StaticData.doneTaskRabunDekat==true)
        {
            iconRabunDekat.color = Color.green;
        }
        if (StaticData.doneTaskRabunJauh==true)
        {
            iconBtnRabunJauh.color = Color.green;
        }
        if (StaticData.doneTaskCpuMk==true)
        {
            iconCpuMk.color = Color.green;
        }
    }
}
