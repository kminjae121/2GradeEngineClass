using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Input/Player", menuName = "PlayerInput")]
public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
{
    private Controls _control;

    [SerializeField] private LayerMask _whatIsGround;
    public Vector2 MovementKey { get; private set; }

    private Vector3 _WorldPosition;
                
    private Vector2 _screenPosition;

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

        MovementKey = movementKey; 
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

    public Vector3 GetWorldPosition()
    {
        Camera mainCam = Camera.main;// Unity 2022∫Œ≈Õ ≥ª∫Œ ƒ≥ΩÃ¿Ã µ 

        Debug.Assert(mainCam != null, "no MainCam is There");

        Ray cameraRay = mainCam.ScreenPointToRay(_screenPosition);
        if (Physics.Raycast(cameraRay, out RaycastHit hit, mainCam.farClipPlane, _whatIsGround))
        {
            _WorldPosition = hit.point;
        }

        return _WorldPosition;
    }

    public void OnPointer(InputAction.CallbackContext context)
    {
        _screenPosition = context.ReadValue<Vector2>();   
    }
}
