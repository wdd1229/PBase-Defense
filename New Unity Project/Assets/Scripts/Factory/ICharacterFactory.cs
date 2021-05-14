using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏角色工厂父级
/// </summary>
public abstract class ICharacterFactory
{
    //创建角色
    public abstract ISoldier CreatSoldier(Role emSolider, ENUM_Weapon weapon, int lv, Vector3 pos);

    public abstract GameObject CreatRole(Role emType, int lv, Transform root, Vector3 v3);

    public abstract IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWepon, Vector3 SpawnPosition);
    //创建敌人 IEnemy

}
