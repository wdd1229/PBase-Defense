using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色兵营
/// </summary>
public class SoldierCamp : ICamp
{
    //指定武器的类型 
    ENUM_Weapon emWeapon = ENUM_Weapon.Gun;
    //兵营等级
    int Lv = 1;

    //集合
    Vector3 pos;

    public SoldierCamp(GameObject theGameObject, ENUM_Soldier emSoldier, string CampName, string IconSprite, float TrainCoolDown, Vector3 Position) : base(theGameObject, TrainCoolDown, CampName, IconSprite)
    {
        enSoldier = emSoldier;
         pos= Position;
    }

    //武器升级 的消耗
    public override int GetWeaponLevelUpCost()
    {
        //根据武器类型 判断
        if ((emWeapon + 1) >= ENUM_Weapon.Max)
            return 0;
        return 100;
    }

    //拿到训练金币
    public override int GetTrainCost()
    {
        //根据 TrainCost类中的计算方法 计算消耗
        return TrainCost.GetTrainCost(enSoldier, Lv, emWeapon);
    }

    //角色训练
    public override void Train()
    {
        //训练命令
        Debug.Log("训练命令");
        //TrainSoldierCommand trainSoldier = new TrainSoldierCommand(ENUM_Soldier.Rookie,ENUM_Weapon.Gun,5,Vector3.zero);
        //AddCommand(trainSoldier);
    }
}
