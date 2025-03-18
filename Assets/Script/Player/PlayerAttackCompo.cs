using UnityEngine;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponent
{
    [Header("Attack Datas"), SerializeField] private AttackDataSO[] attackDataList;
    [SerializeField] private float comboWindow;
    private Entity _entity;
    private EntityAnimator _entityAnimator;

    private readonly int _attackSpeedHash = Animator.StringToHash("ATTACK_SPEED");
    private readonly int _comboCounterHash = Animator.StringToHash("COMBO_COUNTER");

    private float _attackSpeed = 1f;
    private float _lastAttackTime;

    public int COMBO_COUNTER { get; set; } = 0;

    public float AttackSpeed
    {
        get => _attackSpeed;
        set
        {
            _attackSpeed = value;
            _entityAnimator.SetParam(_attackSpeedHash, _attackSpeed);
        }
    }

    public void Initialize(Entity entity)
    {
        _entity = entity;
        _entityAnimator = entity.GetCompo<EntityAnimator>();
        AttackSpeed = 1f;
    }

    public void Attack()
    {
        bool comboCounterOver = COMBO_COUNTER > 2;
        bool comboWindowExhaust = Time.time >= _lastAttackTime + comboWindow;
        if (comboCounterOver || comboWindowExhaust)
        {
            COMBO_COUNTER = 0;
        }
        _entityAnimator.SetParam(_comboCounterHash, COMBO_COUNTER);
    }

    public void EndAttack()
    {
        COMBO_COUNTER++;
        _lastAttackTime = Time.time;
    }

    public AttackDataSO GetCurrentAttackData()
    {
        Debug.Assert(attackDataList.Length > COMBO_COUNTER, "WW");
        return attackDataList[0];
    }

}
