using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        //Jobs
        Container.DeclareSignal<OnJobExcecutedSignal>();
        //Items
        Container.DeclareSignal<OnItemEquippedSignal>();
        Container.DeclareSignal<OnItemUnequippedSignal>();
        Container.DeclareSignal<OnItemBoughtSignal>();
        //Currency
        Container.DeclareSignal<OnCurrencyChangedSignal>();
        //UI
        Container.DeclareSignal<OnInventoryItemSelectedSignal>();
        Container.DeclareSignal<OnScreenOpenedSignal>();
        Container.DeclareSignal<OnScreenClosedSignal>();
        Container.DeclareSignal<OnFinishUITextAnimationSignal>();
        Container.DeclareSignal<OnPurchaseFailSignal>();
    }
}
