using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTask : MonoBehaviour
{
    public bool checkTaskBagianMata;
    public bool checkTaskProsesMata;
    public bool checkTaskRabunJauh;
    public bool checkTaskRabunDekat;
    public bool checkTaskCpuMk;
    public Task taskChoice;
    public enum Task{
        taskBagianMata,
        taskProsesMata,
        taskRabunJauh,
        taskRabunDekat,
        cpuMK
    }
    private void Awake() {
        CheckStaticTask();
    }

    private void Start() {
        CheckTaskDone(); 
    }

    public void CheckTasks(){
        CheckTaskDone();
    }
    private void CheckTaskDone(){
        
        switch (taskChoice)
        {
            case Task.taskBagianMata : 
                checkTaskBagianMata = true;
                StaticData.doneTaskBagianMata = checkTaskBagianMata;
                break;
            case Task.taskProsesMata:
                checkTaskProsesMata = true;
                StaticData.doneTaskProsesMata = checkTaskProsesMata;
                break;
            case Task.taskRabunJauh:
                checkTaskRabunJauh = true;
                StaticData.doneTaskRabunJauh = checkTaskRabunJauh;
                break;
            case Task.taskRabunDekat:
                checkTaskRabunDekat = true;
                StaticData.doneTaskRabunDekat = checkTaskRabunDekat;
                break;
            default:
            break;
        }
        
    }

    public void TaskCpuMk(){
        if(taskChoice==Task.cpuMK){
            checkTaskCpuMk = true;
            StaticData.doneTaskCpuMk = checkTaskCpuMk;
        }
    }

    private void CheckStaticTask(){
        checkTaskBagianMata = StaticData.doneTaskBagianMata;
        checkTaskProsesMata = StaticData.doneTaskProsesMata;
        checkTaskRabunDekat = StaticData.doneTaskRabunDekat;
        checkTaskRabunJauh = StaticData.doneTaskRabunJauh;
        checkTaskCpuMk = StaticData.doneTaskCpuMk;
    }
}
