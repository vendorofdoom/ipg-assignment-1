using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnerBalance : MonoBehaviour
{
    public Sprite[] stones;
    public ProgressManager pm;
    
    private void UpdateInnerBalance(int level)
    {

        if (level > 8 || level < 0) {
            throw new System.Exception("Unhandled level " + level.ToString());
        }

        GetComponent<Image>().sprite = stones[level];
    }

    private void Update()
    {
        UpdateInnerBalance(pm.tasksCompleted);
    }
}
