using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Home home;
    public int tasksCompleted;

    [SerializeField]
    private int tasksCount;
    private Task[] tasks;

    private void Awake()
    {
        tasksCompleted = 0;
        tasks = FindObjectsOfType<Task>();
        tasksCount = tasks.Length;
    }


    public void CalcProgress()
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
            home.unlockDoor();
            this.enabled = false;
        }

    }

}
