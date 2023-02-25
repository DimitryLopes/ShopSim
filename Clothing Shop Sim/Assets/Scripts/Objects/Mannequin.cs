using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mannequin : MonoBehaviour, IInteractable
{
    private VisualItem item;

    public void Interact()
    {
        //UIManager.ShowBuyItemScreen(item);
        Debug.Log("someone interacted with me, help, I'm Introvert");
    }
}
