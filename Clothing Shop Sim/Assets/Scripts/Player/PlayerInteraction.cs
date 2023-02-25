using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float interactionRange;
    [SerializeField]
    private LayerMask interactableLayer;

    void Update()
    {
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        Debug.DrawRay(transform.position, transform.up * interactionRange, Color.white);
        //settings to change config here, maybe?
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, interactionRange);
            if (hit)
            {
                if (hit.collider.gameObject.layer == interactableLayer.value)
                {
                    IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
                    if (interactable != null)
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }
}
