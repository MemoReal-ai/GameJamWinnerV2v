using UnityEngine;

public class RestoreHeal : Buffs

{
    protected override void ApplyBuff()
    {
       player.RestoreHeal();
    }
}
