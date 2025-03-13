using System;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.OnMoveChange += HandleMovementChange;
    }

    public override void Exit()
    {
        base.Exit();
        _player.PlayerInput.OnMoveChange -= HandleMovementChange;
    }

    private void HandleMovementChange(Vector2 movementKey)
    {
        if (movementKey.magnitude > _inputThreshold)
        {
            _player.ChangeState("MOVE");
        }
    }
}
