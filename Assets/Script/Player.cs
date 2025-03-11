using UnityEngine;

public class Player : Entity
{
    [SerializeField] private PlayerInputSO playerInput;

    [SerializeField] private CharacterMovement _movement;

    protected override void Awake()
    {
        base.Awake();
        _movement = GetCompo<CharacterMovement>();
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
