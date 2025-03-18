using System;
using UnityEngine;

public class PlayerMoveState : PlayerCanAttackState
{
    private CharacterMovement _movement;
    public PlayerMoveState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _movement = entity.GetComponent<CharacterMovement>();

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        Vector2 movementKey = _player.PlayerInput.MovementKey;
        _movement.SetMoveDiretion(movementKey);
        if (movementKey.magnitude < _inputThreshold)
            _player.ChangeState("IDLE");
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void Exit()
    {

        base.Exit();
    }

}
