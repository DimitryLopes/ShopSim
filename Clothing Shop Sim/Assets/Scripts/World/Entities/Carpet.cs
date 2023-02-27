using UnityEngine;
using Zenject;

//Seriously, come up with better names for those
public class Carpet : MonoBehaviour, IInteractable
{
    [Inject]
    private UIManager uIManager;

    public void Interact()
    {
        WorkScreen screen = (WorkScreen)uIManager.GetScreen(ScreenType.WorkScreen);
        screen.Show();
    }
}
