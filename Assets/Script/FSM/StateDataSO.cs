using UnityEngine;

[CreateAssetMenu(fileName = "StateData", menuName = "SO/FSM/StateData", order = 0)]
public class StateDataSO : ScriptableObject
{
    public string stateName;
    public string className;
    public string animParamName;

    //절대 private로 하면 안돼
    public int animationHash;

    private void OnValidate()
    {
        animationHash = Animator.StringToHash(animParamName);
    }
}
