using UnityEngine;

public class HealthUp : Buff
{

    [SerializeField] private int aplayerHealth = 1;


    public override void ApplyBuff(PlayerStats player)
    {
        player.ApllyHealth(aplayerHealth);

    }
}
