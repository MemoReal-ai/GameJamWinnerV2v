using UnityEngine;

public abstract class Buffs:MonoBehaviour

{
    [SerializeField] protected PlayerStats player;
    [SerializeField] protected int cost;
    [SerializeField] protected string name;

    protected abstract void ApplyBuff();

}
