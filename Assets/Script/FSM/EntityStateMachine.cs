using System;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine : MonoBehaviour
{
    public EntityState CurrentState { get; set; }
    private Dictionary<string, EntityState> _states;

    public EntityStateMachine(Entity entity, StateDataSO[] stateList)
    {
        _states = new Dictionary<string, EntityState>();
        foreach(StateDataSO state in stateList)
        {
            Type type = Type.GetType(state.className);
            Debug.Assert(type != null, $"Finding type is null : {state.className}");
            EntityState entityState = Activator.CreateInstance(type, entity, state.animationHash)
                as EntityState;

            _states.Add(state.stateName, entityState);
        }
    }

    public void ChangeState(string newStateName)
    {
        CurrentState?.Exit();
        EntityState newState = _states.GetValueOrDefault(newStateName);
        Debug.Assert(newState != null, $"State is null : {newStateName}");

        CurrentState = newState;
        CurrentState.Enter();
    }

    public void UpdateStateMachine()
    {
        CurrentState?.Update();
    }

    public void FixedUpdateStateMachine()
    {
        CurrentState?.FixedUpdate();
    }
}
