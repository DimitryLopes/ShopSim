using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private Transform playerSpawn;
    [SerializeField]
    private Player player;

    public override void InstallBindings()
    {
        PlayerManager playerManager = new PlayerManager(player, playerSpawn);
        Container.Bind<PlayerManager>().FromInstance(playerManager).AsSingle();
    }
}
