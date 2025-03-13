using UnityEngine;
using UnityEngine.Rendering;

public class Player : Entity
{
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    [SerializeField] private StateDataSO[] stateDataList;

    private EntityStateMachine _stateMachine;

    

    protected override void Awake()
    {
        base.Awake();
        _stateMachine = new EntityStateMachine(this, stateDataList);
    }
    private void Start()
    {
        _stateMachine.ChangeState("IDLE");
    }

    private void Update()
    {
        _stateMachine.UpdateStateMachine();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdateStateMachine();
    }

    public void ChangeState(string NewStatename) => _stateMachine.ChangeState(NewStatename);


}
