using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 训练消耗的计算
/// </summary>
public class TrainCost : ITrainCost
{
    public TrainCost()
    {

    }

    /// <summary>
    /// 根据角色和武器的类型 计算消耗
    /// </summary>
    /// <param name="soldier"></param>
    /// <param name="CampLv"></param>
    /// <param name="weapon"></param>
    /// <returns></returns>
    public override int GetTrainCost(ENUM_Soldier soldier, int CampLv, ENUM_Weapon weapon)
    {
         int Cost= 0;
        //判断角色类型 消耗
        switch (soldier)
        {
            
            case ENUM_Soldier.Rookie:
                Cost = 5;
                break;
            case ENUM_Soldier.Sergeant:
                Cost = 7;
                break;
            case ENUM_Soldier.Captain:
                Cost = 10;
                break;
           
            default:
                break;
        }

        //判断武器类型  消耗
        switch (weapon)
        {
           
            case ENUM_Weapon.Gun:
                Cost += 5;
                break;
            case ENUM_Weapon.Rifle:
                Cost += 7;
                break;
            case ENUM_Weapon.Rocket:
                Cost += 10;
                break;
           
            default:
                break;
        }

        //等级
        Cost += (CampLv - 1) * 2;
        return Cost;

    }
}
