using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager
{
    private Transform actionContainer;
    private GameObject listener;
    private List<Mannequin> mannequins;
    private ItemManager itemManager;

    public WorldManager(Transform actionContainer, List<Mannequin> mannequins, ItemManager itemManager,
        GameObject listener)
    {
        this.actionContainer = actionContainer;
        this.mannequins = mannequins;
        this.itemManager = itemManager;
        this.listener = listener;
        RefreshMannequins();
    }

    public void RefreshMannequins()
    {
        itemManager.RefreshAvailableItems();
        foreach(Mannequin mannequin in mannequins)
        {
            VisualItem item = itemManager.FindAvailableVisualItemForMannequin();
            mannequin.Dress(item);
        }
    }

    public void SetListenerState(bool state)
    {
        listener.SetActive(state);
    }

    public void ActivateWorld()
    {
        actionContainer.gameObject.SetActive(true);
    }
}
