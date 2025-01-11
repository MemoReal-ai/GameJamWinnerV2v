using UnityEngine;

public class RestoreHeal : Buff

{
    protected override void ApplyBuff(PlayerStats player)
    {
       player.RestoreHeal();
    }

  
}
