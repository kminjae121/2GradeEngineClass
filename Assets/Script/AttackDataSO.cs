using UnityEngine;

[CreateAssetMenu(fileName = "AttackDataSO", menuName = "Scriptable Objects/AttackDataSO")]
public class AttackDataSO : ScriptableObject
{
    public string attackName;
    public float movementPower;
    public float damageMuliplier = 1f;
    public float damageIncrease = 0;
    public bool isPowerAttack;

    private void OnEnable()
    {
        attackName = this.name;
    }
}
