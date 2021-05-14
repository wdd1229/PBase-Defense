using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSorcerer : ISoldier
{
    public SoldierSorcerer()
    {
        //法师
        m_emSoldier = Role.Sorcerer;
        m_AssetName = "2";
        m_AttrID = 2;
    }

    public override void PlayAaudio()
    {

    }

    public override void PlayEffect()
    {

    }
}
