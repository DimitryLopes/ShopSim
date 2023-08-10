using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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
    private PlayerClothes clothes;
    private int animationFrameIndex;
    private Dictionary<ItemType, SpriteRenderer> Clothes;

    [SerializeField, Space, Header("Interaction")]
    private LayerMask interactableLayer;
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

    private void Start()
    {
        CreateClothesDictionary();
    }

    private void CreateClothesDictionary()
    {
        Clothes = new Dictionary<ItemType, SpriteRenderer>();
        for (int i = 0; i < clothes.Renderers.Count; i++)
        {
            Clothes.Add(clothes.Types[i], clothes.Renderers[i]);
            VisualItem item = itemManager.Inventory.EquipedItems[clothes.Types[i]];
            if (item != null)
            {
                EquipItem(item);
            }
        }
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
                IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
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
        
        rigidbody2D.velocity = movementVector.normalized * movementSpeed;
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
        EquipItem(signal.Item);
    }

    private void EquipItem(VisualItem item)
    {
        Clothes[item.Type].sprite = item.SpriteSheet[animationFrameIndex];
    }

    private void OnItemUnequiped(OnItemUnequippedSignal signal)
    {
        Clothes[signal.Type].sprite = null;
    }


    public void OnSpriteChanged(int index)
    {
        animationFrameIndex = index;
        VisualItem headItem = itemManager.Inventory.EquipedItems[ItemType.HeadClothing];
        if (headItem != null)
        {
            Clothes[ItemType.HeadClothing].sprite = headItem.SpriteSheet[animationFrameIndex];
        }

        VisualItem bodyItem = itemManager.Inventory.EquipedItems[ItemType.BodyClothing];
        if (bodyItem != null)
        {
            Clothes[ItemType.BodyClothing].sprite = bodyItem.SpriteSheet[animationFrameIndex];
        }

        VisualItem shoesItem = itemManager.Inventory.EquipedItems[ItemType.ShoesClothing];
        if (shoesItem != null)
        {
            Clothes[ItemType.ShoesClothing].sprite = shoesItem.SpriteSheet[animationFrameIndex];
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

    [Serializable]
    private struct PlayerClothes
    {
        [SerializeField]
        private List<SpriteRenderer> renderers;
        [SerializeField]
        private List<ItemType> types;

        public List<SpriteRenderer> Renderers => renderers;
        public List<ItemType> Types => types;
    }

}
