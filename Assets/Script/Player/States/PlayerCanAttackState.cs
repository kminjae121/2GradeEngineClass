using UnityEngine;

public class PlayerCanAttackState : PlayerState
{
    public PlayerCanAttackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        _player.PlayerInput.OnAttackPress += HandleAttackPressed;
        base.Enter();
    }

    public override void Exit()
    {
        _player.PlayerInput.OnAttackPress -= HandleAttackPressed;
        base.Exit();
    }

    private void HandleAttackPressed()
    {
        _player.ChangeState("ATTACK");
    }
}
