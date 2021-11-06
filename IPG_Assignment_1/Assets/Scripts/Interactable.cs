using UnityEngine;

// Brackeys RPG tutorial: https://youtu.be/9tePzyL6dgc
// Interactable tutorial: https://youtu.be/858X6_WHfuw

public abstract class Interactable : MonoBehaviour
{
    public abstract string GetDescription();
    public abstract void Interact();

}

