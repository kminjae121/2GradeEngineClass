using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInputSO playerInput;
    [SerializeField] private CharacterMovement _movement;


    private void Awake()
    {
        playerInput.OnMoveChange += HandleMoveChange;
    }

    private void OnDestroy()
    {
        playerInput.OnMoveChange -= HandleMoveChange;
    }

    private void HandleMoveChange(Vector2 vector)
    {
        _movement.SetMoveDiretion(vector);
    }
}
