using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private int tasksCompleted;
    private int tasksCount;
    private Task[] tasks;

    private void Awake()
    {
        tasksCompleted = 0;
        tasks = FindObjectsOfType<Task>();
        tasksCount = tasks.Length;
    }


    private void CalcProgress()
    {

        tasksCompleted = 0;
        foreach (Task task in tasks)
        {
            if (task.isComplete)
            {
                tasksCompleted += 1;
            }
        }
        
        if (tasksCompleted == tasksCount)
        {
            GetComponent<GameManager>().TasksComplete();
            this.enabled = false;
        }

    }

    private void Update()
    {
        CalcProgress();
    }


}
