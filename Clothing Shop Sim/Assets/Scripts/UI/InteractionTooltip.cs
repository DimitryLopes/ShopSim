using UnityEngine;

public class InteractionTooltip : MonoBehaviour
{
    public void Enable(bool value)
    {
        if (gameObject.activeSelf != value)
        {
            gameObject.SetActive(value);
        }
    }
}
