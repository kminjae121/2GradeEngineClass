using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Input/Player", menuName = "PlayerInput")]
public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
{
    private Controls _control;

    public event Action<Vector2> OnMoveChange;

    public event Action OnRoiilingPress, OnAttackPress, OnJumpPress;
    private void OnEnable()
    {
        if(_control == null)
        {
            _control = new Controls();
            _control.Player.SetCallbacks(this);
        }
        _control.Player.Enable();
    }

    private void OnDisable()
    {
        _control.Player.Disable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnAttackPress?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementKey = context.ReadValue<Vector2>();

        OnMoveChange?.Invoke(movementKey);  
    }

    public void OnRolling(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnRoiilingPress?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnJumpPress?.Invoke();

    }
}
