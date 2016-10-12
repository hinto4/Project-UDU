using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class BoxMovementController : MonoBehaviour
{
    public float RotationSpeed;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
            _rb.MoveRotation(_rb.rotation + RotationSpeed * Time.fixedDeltaTime);
        }
        if (inputValue > 0)
        {
            _rb.MoveRotation(_rb.rotation - RotationSpeed * Time.fixedDeltaTime);
        }
    }
}
