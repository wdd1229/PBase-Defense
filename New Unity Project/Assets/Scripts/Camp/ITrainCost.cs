using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 训练所需要的消耗
/// </summary>
public abstract class ITrainCost  
{
    public abstract int GetTrainCost(ENUM_Soldier soldier, int CampLv, ENUM_Weapon weapon);
}
