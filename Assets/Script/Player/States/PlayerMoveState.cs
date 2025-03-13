using System;
using UnityEngine;

public class PlayerMoveState :PlayerState
{
    public PlayerMoveState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.OnMoveChange += HandleMovementChange;
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void Exit()
    {
        _player.PlayerInput.OnMoveChange -= HandleMovementChange;

        base.Exit();
    }

    private void HandleMovementChange(Vector2 movementKey)
    {
        if (movementKey.magnitude < _inputThreshold)
            _player.ChangeState("IDLE");
    }
}
