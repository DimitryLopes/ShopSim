using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WorldInstaller : MonoInstaller
{
    [Inject]
    private ItemManager itemManager;

    [SerializeField]
    private Transform actionContainer;
    [SerializeField]
    private List<Mannequin> mannequins;

    public override void InstallBindings()
    {
        WorldManager worldManager = new WorldManager(actionContainer, mannequins, itemManager);
        Container.Bind<WorldManager>().FromInstance(worldManager).AsSingle();
    }
}
