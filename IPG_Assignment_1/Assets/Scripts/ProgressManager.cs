using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private int tasksCompleted;
    private int tasksCount;
    private Task[] tasks;

    [SerializeField]
    private float progress = 0f;

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

        if (tasksCount == 0)
        {
            progress = 0f;
        }

        if (tasksCount == tasksCompleted) {
            progress = 1f;
        }

        progress = (float)tasksCompleted / (float)tasksCount;
        
    }

    private void Update()
    {
        CalcProgress();
    }


}
