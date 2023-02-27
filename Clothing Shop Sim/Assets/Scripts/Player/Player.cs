using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string HORIZONTAL_AXIS = "Horizontal";
    private string VERTICAL_AXIS = "Vertical";
    private string LAST_VERTICAL_INPUT = "LastMoveVertical";
    private string LAST_HORIZONTAL_INPUT = "LastMoveHorizontal";
    private string ANIMATION_KEY_SPEED = "Speed";

    [SerializeField, Header("Movement")]
    private float movementSpeed;
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    private Vector2 movementVector;

    [SerializeField, Header("Animation")]
    private Animator animator;

    [SerializeField, Space, Header("Interaction")]
    private string interactableTag;
    [SerializeField]
    private float interactionRange;
    private Vector2 lastMovement;
    private bool canInteract = true;
    private bool canMove = true;

    private void Update()
    {
        if (canInteract)
        {
            HandleInteraction();
        }

        if (canMove)
        {
            HandleMovement();
        }

        HandleAnimation();
    }

    #region interaction
    public void SetInteractionState(bool state)
    {
        canInteract = state;
    }

    private void HandleInteraction()
    {
        Debug.DrawRay(transform.position, lastMovement.normalized * interactionRange, Color.red);
        //settings to change config here, maybe?
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lastMovement.normalized, interactionRange);
            if (hit)
            {
                if (hit.collider.gameObject.tag == interactableTag)
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
    #endregion

    #region movement
    public void SetMovementState(bool state)
    {
        canMove = state;
    }

    private void HandleMovement()
    {
        movementVector.x = Input.GetAxisRaw(HORIZONTAL_AXIS);
        movementVector.y = Input.GetAxisRaw(VERTICAL_AXIS);

        if(movementVector != Vector2.zero)
        {
            lastMovement = movementVector;
        }
        
        rigidbody2D.velocity = movementVector.normalized * movementSpeed * Time.deltaTime;
    }
    #endregion

    #region Animation
    private void HandleAnimation()
    {
        animator.SetFloat(HORIZONTAL_AXIS, movementVector.x);
        animator.SetFloat(VERTICAL_AXIS, movementVector.y);
        animator.SetFloat(ANIMATION_KEY_SPEED, movementVector.sqrMagnitude);

        if(movementVector != Vector2.zero)
        {
            animator.SetFloat(LAST_HORIZONTAL_INPUT, movementVector.x);
            animator.SetFloat(LAST_VERTICAL_INPUT, movementVector.y);
        }
    }
    #endregion
    public void SetPlayerActions(bool state)
    {
        SetMovementState(state);
        SetInteractionState(state);
        if(state == false)
        {
            movementVector = Vector2.zero;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
