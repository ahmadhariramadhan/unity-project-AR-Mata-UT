using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTask : MonoBehaviour
{
    
    public bool checkTask;
    public Task taskChoice;
    public enum Task{
        taskBagianMata,
        taskProsesMata,
        taskRabunJauh,
        taskRabunDekat
    }

    private void OnEnable() {
        if (!checkTask)
        {
            CheckTaskDone();
            print(checkTask);
        }return;
    }



    private void CheckTaskDone(){
        switch (taskChoice)
        {
            case Task.taskBagianMata : 
                checkTask = true;
                StaticData.doneTaskBagianMata = checkTask;
                break;
            case Task.taskProsesMata:
                checkTask = true;
                StaticData.doneTaskProsesMata = checkTask;
                break;
            case Task.taskRabunDekat:
                checkTask = true;
                StaticData.doneTaskRabunDekat = checkTask;
                break;
            case Task.taskRabunJauh:
                checkTask = true;
                StaticData.doneTaskRabunJauh = checkTask;
                break;
            default:
            break;
        }
        
    }
}
