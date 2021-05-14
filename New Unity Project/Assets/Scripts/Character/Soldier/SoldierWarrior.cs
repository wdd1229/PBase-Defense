using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierWarrior : ISoldier
{
    public SoldierWarrior()
    {
        //战士
        m_emSoldier = Role.Warrior;
        m_AssetName = "0";
        m_AttrID = 0;
    }

    public override void PlayAaudio()
    {
         
    }

    public override void PlayEffect()
    {
         
    }
}
