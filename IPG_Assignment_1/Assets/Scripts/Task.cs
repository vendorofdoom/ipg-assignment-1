using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public bool isComplete = false;
    private ProgressManager pm;

    [Header("Audio")]
    public AudioClip audioClip;
    public AudioSource audioSource;

    public void Awake()
    {
        pm = GameObject.Find("Managers").GetComponent<ProgressManager>();
    }

    public void Complete()
    {
        isComplete = true;
        pm.CalcProgress();

        if (audioClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        
    }

}
