using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private ItemManager itemManager;

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
    private bool canMove = true;

    [SerializeField, Header("Animation")]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer hatRenderer;
    [SerializeField]
    private SpriteRenderer bodyRenderer;
    [SerializeField]
    private SpriteRenderer shoesRenderer;
    private int animationFrameIndex;
    private Dictionary<ItemType, SpriteRenderer> clothRenderers = new Dictionary<ItemType, SpriteRenderer>();

    [SerializeField, Space, Header("Interaction")]
    private LayerMask interactableLayer;
    [SerializeField]
    private string interactableTag;
    [SerializeField]
    private float interactionRange;
    [SerializeField]
    private Transform interactionStartPoint;
    private Vector2 lastMovement;
    private bool canInteract = true;

    private void OnEnable()
    {
        signalBus.Subscribe<OnItemEquippedSignal>(OnItemEquiped);
        signalBus.Subscribe<OnItemUnequippedSignal>(OnItemUnequiped);
    }

    private void OnDisable()
    {
        signalBus.Unsubscribe<OnItemEquippedSignal>(OnItemEquiped);
        signalBus.Unsubscribe<OnItemUnequippedSignal>(OnItemUnequiped);
    }

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

    private void Start()
    {
        //doesn't need to be hardcoded, but I'll look into later
        clothRenderers.Add(ItemType.HeadClothing, hatRenderer);
        clothRenderers.Add(ItemType.BodyClothing, bodyRenderer);
        clothRenderers.Add(ItemType.ShoesClothing, shoesRenderer);
    }

    #region interaction
    public void SetInteractionState(bool state)
    {
        canInteract = state;
    }

    private void HandleInteraction()
    {
        Debug.DrawRay(interactionStartPoint.position, lastMovement.normalized * interactionRange, Color.red);
        //settings to change config here, maybe?
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(interactionStartPoint.position, lastMovement.normalized, interactionRange, interactableLayer);
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

    private void OnItemEquiped(OnItemEquippedSignal signal)
    {
        VisualItem item = itemManager.Inventory.EquipedItems[signal.Item.Type];
        clothRenderers[item.Type].sprite = item.SpriteSheet[animationFrameIndex];
    }

    private void OnItemUnequiped(OnItemUnequippedSignal signal)
    {
        clothRenderers[signal.Type].sprite = null;
    }

    //I'm not sure if this is legal. Called on animations
    public void OnSpriteChanged(int index)
    {
        animationFrameIndex = index;
        VisualItem headItem = itemManager.Inventory.EquipedItems[ItemType.HeadClothing];
        if (headItem != null)
        {
            hatRenderer.sprite = headItem.SpriteSheet[animationFrameIndex];
        }

        VisualItem bodyItem = itemManager.Inventory.EquipedItems[ItemType.BodyClothing];
        if (bodyItem != null)
        {
            bodyRenderer.sprite = bodyItem.SpriteSheet[animationFrameIndex];
        }

        VisualItem shoesItem = itemManager.Inventory.EquipedItems[ItemType.ShoesClothing];
        if (shoesItem != null)
        {
            shoesRenderer.sprite = shoesItem.SpriteSheet[animationFrameIndex];
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
