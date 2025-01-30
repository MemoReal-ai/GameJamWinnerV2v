using UnityEngine;
using UnityEngine.UI;

public abstract class Buff : MonoBehaviour

{
    [SerializeField] protected PlayerStats player;
    [SerializeField] protected int cost;
    [SerializeField] protected string nameBuff;
    [SerializeField] protected Sprite image;
    [SerializeField] protected Button button;

    public Button Button => button;

    public int Cost => cost;
    public string Name => nameBuff;
    public Sprite Image => image;
    public abstract void ApplyBuff(PlayerStats player);

}
