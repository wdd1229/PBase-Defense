using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色的数值 计算策略
/// </summary>
public class SoldierAttrStrategy : IAttrStrategy
{
    public override void InitAttr(ICharacterAttr CharacterAttr)
    {
        // 是否为士兵
        SoldierAttr theSoldierAttr = CharacterAttr as SoldierAttr;

        //获取等级

        //根据等级 AddMaxHP = (Lv-1)*2; 计算出增加的血量 设置给theSoldierAttr 

    }

    //攻击加成
    public override int GetAtkPlusValue(ICharacterAttr CharacterAttr)
    {
        //士兵无加成
        return 0;
    }

    //减伤
    public override int GetDmgDescValue(ICharacterAttr CharacterAttr)
    {
        // 是否为士兵
        SoldierAttr theSoldierAttr = CharacterAttr as SoldierAttr;

        //根据公式计算 减伤值 
        // return theSoldierAttr.GetSoldierLv()-1)*2;;
        return 0;
    }


}
