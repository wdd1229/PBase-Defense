using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 怪物 狼
/// </summary>
public class EnemyWolf : IEnemy
{
     public EnemyWolf()
    {
        m_emEnemyType = ENUM_Enemy.Wolf;
        m_AssetName = "wolf";
        m_AttrID = 1;
        
    }

    public override void PlayAaudio()
    {
         
    }

    public override void PlayEffect()
    {
         
    }
}
