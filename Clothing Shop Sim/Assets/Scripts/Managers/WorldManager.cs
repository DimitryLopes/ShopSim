using System.Collections.Generic;
using UnityEngine;

public class WorldManager
{
    private PlayerManager playerManager;
    private Transform actionContainer;
    private GameObject listener;
    private List<Mannequin> mannequins;
    private ItemManager itemManager;

    public WorldManager(Transform actionContainer, List<Mannequin> mannequins, ItemManager itemManager,
        GameObject listener, PlayerManager playerManager)
    {
        this.actionContainer = actionContainer;
        this.mannequins = mannequins;
        this.itemManager = itemManager;
        this.listener = listener;
        this.playerManager = playerManager;
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

    public void SetWorldState(bool state)
    {
        playerManager.ResetPlayerPosition();
        actionContainer.gameObject.SetActive(state);
    }
}
