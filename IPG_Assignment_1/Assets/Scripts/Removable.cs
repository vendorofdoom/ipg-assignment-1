using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removable : Interactable
{ 
    public GameObject Obj;
    public string itemToTidy;
    public override string GetDescription()
    {
        return "Press [E] to tidy up the " + itemToTidy;
    }
    
    public override void Interact()
    {
        Obj.SetActive(false);  
    }

}
