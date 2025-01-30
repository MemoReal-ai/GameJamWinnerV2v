using UnityEngine;

public class DamageUp : Buff
{
    [SerializeField] private int aplyerDamage = 1;
 

    public override void ApplyBuff(PlayerStats player)
    {
        player.ApllyDamage(aplyerDamage);
        
    }
}
