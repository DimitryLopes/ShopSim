using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerVisual playerVisual;
    [SerializeField]
    private PlayerInteraction playerInteraction;

    public void SetInteractionState(bool state)
    {
        playerInteraction.enabled = state;
    }

    public void SetMovementState(bool state)
    {
        playerMovement.enabled = state;
    }

    public void SetPlayerState(bool state)
    {
        SetMovementState(state);
        SetInteractionState(state);
    }

    public void SetVisualOnPlayer()
    {

    }
}
