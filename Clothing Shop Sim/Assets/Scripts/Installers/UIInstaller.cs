using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private ScreenDatabase screenDatabase;

    public override void InstallBindings()
    {
        UIManager uIManager = new UIManager(screenDatabase, eventSystem);
        Container.Bind<UIManager>().FromInstance(uIManager).AsSingle();
    }
}
