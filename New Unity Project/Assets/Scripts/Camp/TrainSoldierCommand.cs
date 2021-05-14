using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 训练角色 命令的具体逻辑类
/// </summary>
public class TrainSoldierCommand : ITrainCommand
{

    Role emSoldier;//角色的类型

    ENUM_Weapon emWeapon;//角色的武器

    int Lv;//等级
    Vector3 Pos;//角色 的初始位置

    //构造赋值
    public TrainSoldierCommand(Role RoleType,int lv,Vector3 v3)
    {
        emSoldier = RoleType;
        //emWeapon = weapon;
        Lv = lv;
        Pos = v3;
    }

    //执行逻辑
    public override void Execute()
    {
        Debug.Log("创建角色命令执行类");
        //从PBDF中获得创建角色工厂 通过工厂创建角色
        ICharacterFactory factory = PBDFactory.GetCharacterFactory();

        ISoldier soldier = factory.CreatSoldier(emSoldier, emWeapon, Lv, Pos);

        //随机角色的能力

        //从PBDF中获得工厂 数值的
        IAttrFactory AttrFactory = PBDFactory.GetAttrFactory();

        PlayerData playerData = PBaseDefenseGame.Instance.GetPlayerData();
        //SoldierAttr PreAttr=AttrFactory.GetEliteSoldierAttr(ENUM_Attr.Player, (int)playerData.RoleType, soldier)

        //吧数值设置个给角色

    }

}
