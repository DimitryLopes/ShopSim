using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private string HORIZONTAL_AXIS = "horziontal";
    private string VERTICAL_AXIS = "vertical";

    private float horizontalAxisInputThisFrame;
    private float verticalAxisInputThisFrame;

    [SerializeField]
    private float movementSpeed;

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        horizontalAxisInputThisFrame = Input.GetAxis(HORIZONTAL_AXIS);
        verticalAxisInputThisFrame = Input.GetAxis(VERTICAL_AXIS);

        Vector2 movementVector = new Vector2(horizontalAxisInputThisFrame, verticalAxisInputThisFrame);

        float movementMagnitude = Mathf.Clamp01(movementVector.magnitude);
        movementVector.Normalize();


        transform.Translate(movementVector * movementSpeed * movementMagnitude * Time.deltaTime, Space.World);
    }
}
