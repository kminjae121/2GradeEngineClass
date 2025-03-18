using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttackState : PlayerState
{
   
    private PlayerAttackCompo _attackCompo;

    private CharacterMovement _movement;
    public PlayerAttackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _attackCompo = entity.GetCompo<PlayerAttackCompo>();
    }

    public override void Enter()
    {
        base.Enter();
        _attackCompo.Attack();
        _movement = _entity.GetCompo<CharacterMovement>();

        AttackDataSO CURRENTaTKdATA = _attackCompo.GetCurrentAttackData();
        Vector3 playerDiretion = _player.transform.forward;
        _player.transform.rotation = Quaternion.LookRotation(playerDiretion);

        Vector3 movement = playerDiretion * CURRENTaTKdATA.movementPower;
        _movement.CanManualMovement = false;
        _movement.SetAutoMovement(movement);
    }

    private void EndAttack()
    {
        _player.ChangeState("IDLE");
    }

    public override void Exit()
    {
        _attackCompo.EndAttack();
        _movement.CanManualMovement = false;
        base.Exit();
        _movement.StopImmediately();

    }

    public override void Update()
    {
        base.Update();
        if (_isTriggerCall)
            EndAttack();
    }

   
}
