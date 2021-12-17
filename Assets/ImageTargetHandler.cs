using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ImageTargetHandler : MonoBehaviour
{
    public List<easyar.ImageTargetController> asd = new List<easyar.ImageTargetController>();
    public List<CheckTask> checkTasks = new List<CheckTask>();
    private void Awake()
    {
        DisableAll();
        EnableByIndex();
    }

    void Start()
    {
    }

    void DisableAll()
    {
        if (asd.Count > 0)
        {
            foreach (var item in asd)
            {
                item.enabled = false;
                item.gameObject.SetActive(false);
            }
        }
    }

    void EnableByIndex()
    {
        asd[StaticData.index].gameObject.SetActive(true);
        asd[StaticData.index].enabled = true;
    }

    public void CheckTaskDone(){
        checkTasks[0].checkTask = StaticData.doneTaskBagianMata;
        checkTasks[1].checkTask = StaticData.doneTaskProsesMata;
        checkTasks[2].checkTask = StaticData.doneTaskRabunJauh;
        checkTasks[3].checkTask = StaticData.doneTaskRabunDekat;
    }
}
