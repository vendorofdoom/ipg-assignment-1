using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchPile : Interactable
{
    public GameObject branches;

    public override string GetDescription()
    {
        return "Press [E] to tidy up the branches";
    }
    
    public override void Interact()
    {
        GetComponent<Task>().Complete();
        branches.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
    }

}
