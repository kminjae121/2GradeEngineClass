using System;
using UnityEngine;

public class PlayerIdleState : PlayerCanAttackState
{
    private CharacterMovement _movement;

    public PlayerIdleState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _movement = _player.GetComponent<CharacterMovement>();
    }

    public override void Update()
    {
        base.Update();


        Vector2 movementKey = _player.PlayerInput.MovementKey;
        _movement.SetMoveDiretion(movementKey);
        if (movementKey.magnitude > _inputThreshold)
        {
            _player.ChangeState("MOVE");
        }
    }



    private void HandleAttackPressed()
    {
        _player.ChangeState("ATTACK");
    }


    
}
