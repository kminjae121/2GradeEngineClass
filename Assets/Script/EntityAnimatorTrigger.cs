using System;
using UnityEngine;

public class EntityAnimatorTrigger :MonoBehaviour, IEntityComponent
{
    public Action OnAnimationEndTrigger;

    private Entity _entity;
    public void Initialize(Entity entity)
    {
        _entity = entity;
    }

    public void AnimationEnd()
    {
        OnAnimationEndTrigger?.Invoke();
    }
}
