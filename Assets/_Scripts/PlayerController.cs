using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float RotationSpeed = 100f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        BoxRotationMovement();
    }

    private void BoxRotationMovement()
    {
        float inputValue = CrossPlatformInputManager.GetAxis("Horizontal");

        if (inputValue < 0)
        {
            rb.MoveRotation(rb.rotation + RotationSpeed * Time.fixedDeltaTime);
        }
        if (inputValue > 0)
        {
            rb.MoveRotation(rb.rotation - RotationSpeed * Time.fixedDeltaTime);
        }
    }
}
