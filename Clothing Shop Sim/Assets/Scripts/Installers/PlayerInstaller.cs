using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private Player player;

    public override void InstallBindings()
    {
        PlayerManager playerManager = new PlayerManager(player);
        Container.Bind<PlayerManager>().FromInstance(playerManager).AsSingle();
    }
}
