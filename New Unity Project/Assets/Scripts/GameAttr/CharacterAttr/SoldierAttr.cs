using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色的数值
/// </summary>
public class SoldierAttr : ICharacterAttr
{
    protected int m_Lv;//角色等级
    protected int AddHp;//因为等级而增加的hp

    public SoldierAttr() { }

    //设置角色的数值
    public void SetSoldierAttr(BaseAttr baseAttr)
    {
        base.SetBaseAttr(baseAttr);

        m_Lv = 1;
        AddHp = 0;
    }

    public override int GetMaxHP()
    {
        //加上 等级而多的血量
        return base.GetMaxHP()+AddHp;
    }
}
