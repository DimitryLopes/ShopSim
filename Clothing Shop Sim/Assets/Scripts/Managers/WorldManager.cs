using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager
{
    private Transform actionContainer;
    private List<Mannequin> mannequins;
    private ItemManager itemManager;

    public WorldManager(Transform actionContainer, List<Mannequin> mannequins, ItemManager itemManager)
    {
        this.actionContainer = actionContainer;
        this.mannequins = mannequins;
        this.itemManager = itemManager;
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

    public void ActivateWorld()
    {
        actionContainer.gameObject.SetActive(true);
    }
}
