using UnityEngine;

public abstract class EntityState
{
    protected Entity _entity;
    protected int _animationHash;
    protected EntityAnimator _entityAnimator;
    protected bool _isTriggerCall;

    public EntityState(Entity entity, int animationHash)
    {
        _entity = entity;
        _animationHash = animationHash;
        _entityAnimator = entity.GetCompo<EntityAnimator>();
    }

    public virtual void Enter()
    {
        _entityAnimator.SetParam(_animationHash, true);
        _isTriggerCall = false;
    }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }

    public virtual void Exit()
    {
        _entityAnimator.SetParam(_animationHash, false);
    }

    public virtual void AnimationEndTrigger() => _isTriggerCall = true;
}
