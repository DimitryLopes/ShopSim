using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WorldInstaller : MonoInstaller
{
    [Inject]
    private PlayerManager playerManager;
    [Inject]
    private ItemManager itemManager;

    [SerializeField]
    private GameObject listener;
    [SerializeField]
    private Transform actionContainer;
    [SerializeField]
    private List<Mannequin> mannequins;

    public override void InstallBindings()
    {
        WorldManager worldManager = new WorldManager(actionContainer, mannequins, itemManager, listener, playerManager);
        Container.Bind<WorldManager>().FromInstance(worldManager).AsSingle();
    }
}
