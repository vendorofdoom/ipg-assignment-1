using UnityEngine;

// Interactable tutorial: https://youtu.be/858X6_WHfuw

public class LanternLight : Interactable
{
    public bool SwitchedOn;

    public MeshRenderer MeshRenderer;

    public Material OnMat;
    public Material OffMat;

    private void Start()
    {
        SwitchedOn = false;
    }

    public override string GetDescription()
    {
        if (SwitchedOn)
        {
            return "Click to blow out the lantern";
        } else
        {
            return "Click to light the lantern";
        }
        
    }

    public override void Interact()
    {
        SwitchedOn = !SwitchedOn;

        if (SwitchedOn)
        {
            MeshRenderer.material = OnMat;
        }
        else
        {
            MeshRenderer.material = OffMat;
        }
    }

}
