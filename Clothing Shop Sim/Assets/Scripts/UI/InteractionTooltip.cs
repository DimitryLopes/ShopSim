using UnityEngine;

public class InteractionTooltip : MonoBehaviour
{
    private bool locked;
    public void Enable(bool value)
    {
        if (!locked && gameObject.activeSelf != value)
        {
            gameObject.SetActive(value);
        }
    }

    public void SetLockocked(bool value)
    {
        locked = value;
    }
}
