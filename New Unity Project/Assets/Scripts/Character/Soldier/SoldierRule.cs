using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRule : ISoldier
{
    public SoldierRule()
    {
        //法师
        m_emSoldier = Role.Rule;
        m_AssetName = "1";
        m_AttrID = 1;
    }

    public override void PlayAaudio()
    {

    }

    public override void PlayEffect()
    {

    }
}
