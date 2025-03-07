using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f, gravity = -9.81f;
    [SerializeField] CharacterController characeterController;
    [SerializeField] private Transform parent;

    [SerializeField] private float rotationSpeed = 8f;
    public bool IsGround => characeterController.isGrounded;

    private Vector3 _velocity;

    public Vector3 Velocity => _velocity;

    private float _verticalVelocity;

    private Vector3 _movementDirection;


    public void SetMoveDiretion(Vector2 moveInput)
    {
        _movementDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;
    }

    private void FixedUpdate()
    {
        CalculateMovement();
        ApplyGravity();
        Move();
    }

    private void ApplyGravity()
    {
        if (IsGround && _verticalVelocity < 0)
            _verticalVelocity = -0.03f;
        else
            _verticalVelocity += gravity * Time.fixedDeltaTime;

        _velocity.y = _verticalVelocity;
    }

    private void CalculateMovement()
    {
        _velocity = Quaternion.Euler(0, -45f, 0) * _movementDirection;

        _velocity *= moveSpeed * Time.fixedDeltaTime;

        if (_velocity.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_velocity);
            parent.rotation = Quaternion.Lerp(parent.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
        }
    }

    private void Move()
    {
        characeterController.Move(_velocity);
    }
}
