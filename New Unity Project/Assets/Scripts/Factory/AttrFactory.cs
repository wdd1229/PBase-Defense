using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrFactory : IAttrFactory
{
    public override AdditionalAttr GetAdditionalAttr(int AttrID)
    {
        throw new System.NotImplementedException();
    }

    public override SoldierAttr GetEliteSoldierAttr(ENUM_Attr emType, int AttrID, SoldierAttr theSoldierAttr)
    {



        return null;
    }

    public override SoldierAttr GetSoldierAttr(int AttrID)
    {
        throw new System.NotImplementedException();
    }

    public override WeaponAttr GetWeaponAttr(int AttrID)
    {
        throw new System.NotImplementedException();
    }

    public override EnemyAttr GetEnemyAttr(int AttrID)
    {
        return null;
    }
}
