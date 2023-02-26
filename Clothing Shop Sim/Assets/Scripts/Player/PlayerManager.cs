using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager 
{
    private Player player;
    private PlayerInventory inventory;

    public PlayerInventory Inventory => inventory;

    public PlayerManager(Player player, PlayerInventory inventory)
    {
        this.player = player;
        this.inventory = inventory;
    }

    public void AllowPlayerActions(bool value)
    {
        player.SetPlayerActions(value);
    }
}
