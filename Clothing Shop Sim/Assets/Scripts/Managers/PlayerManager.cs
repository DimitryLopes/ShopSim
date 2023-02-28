using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager 
{
    private Player player;
    private Transform playerSpawn;

    public PlayerManager(Player player, Transform playerSpawn)
    {
        this.player = player;
        this.playerSpawn = playerSpawn;
    }

    public void AllowPlayerActions(bool value)
    {
        player.SetPlayerActions(value);
    }

    public void ResetPlayerPosition()
    {
        player.transform.position = playerSpawn.position;
    }

    public void SetPlayerState(bool state)
    {
        player.gameObject.SetActive(state);
    }
}
