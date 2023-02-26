using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private ScreenDatabase screenDatabase;

    public override void InstallBindings()
    {
        UIManager uIManager = new UIManager();
        uIManager.Load(screenDatabase, eventSystem);
        Container.Bind<UIManager>().FromInstance(uIManager).AsSingle();
    }
}
