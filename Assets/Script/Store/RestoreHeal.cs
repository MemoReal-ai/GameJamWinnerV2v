using UnityEngine;

public class RestoreHeal : Buff

{
    public override void ApplyBuff(PlayerStats playerStats)
    {
        playerStats.RestoreHeal();
    }


}
