using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager 
{
    private Player player;

    public PlayerManager(Player player)
    {
        this.player = player;
    }

    public void AllowPlayerActions(bool value)
    {
        player.SetPlayerActions(value);
    }
}
