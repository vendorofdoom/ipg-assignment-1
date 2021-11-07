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

    private void updateCompletedTasks()
    {
        tasksCompleted = 0;
        foreach (Task task in tasks)
        {
            if (task.isComplete)
            {
                tasksCompleted += 1;
            }
        }
    }

    private float GetProgress()
    {

        updateCompletedTasks();


        if (tasksCount == 0)
        {
            return 0f;
        }

        if (tasksCount == tasksCompleted) {
            return 1f;
        }

        return (float)tasksCompleted / (float)tasksCount;
        
    }

    private void Update()
    {
        //Debug.Log(GetProgress().ToString());
    }


}
