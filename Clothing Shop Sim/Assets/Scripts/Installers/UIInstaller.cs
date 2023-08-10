using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [Inject]
    private SignalBus signalBus;

    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private TextWriter textWriter;
    [SerializeField]
    private ScreenDatabase screenDatabase;

    public override void InstallBindings()
    {
        UIManager uIManager = new UIManager(screenDatabase, signalBus, eventSystem);
        Container.Bind<UIManager>().FromInstance(uIManager).AsSingle();
        Container.Bind<TextWriter>().FromInstance(textWriter).AsSingle();
    }
}
