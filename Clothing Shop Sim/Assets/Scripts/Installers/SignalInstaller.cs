using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<OnCurrencyChangedSignal>();
        Container.DeclareSignal<OnInventoryItemSelectedSignal>();
        Container.DeclareSignal<OnJobExcecutedSignal>();
        Container.DeclareSignal<OnItemEquippedSignal>();
        Container.DeclareSignal<OnItemUnequippedSignal>();
        Container.DeclareSignal<OnItemBoughtSignal>();
    }
}
