using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏角色工厂
/// </summary>
public class CharacterFactory : ICharacterFactory
{
    //角色建造者
    private CharacterBuilderSystem BuilderDirector = new CharacterBuilderSystem(PBaseDefenseGame.Instance);

    //建立角色
    public override ISoldier CreatSoldier(Role emSolider, ENUM_Weapon weapon, int lv, Vector3 pos)
    {
        //角色需要的参数
        SoldierBuildParam soldierParam = new SoldierBuildParam();

        //判断角色类型 创建对应对象
        switch (emSolider)
        {
           
            case Role.Warrior:
                //soldierParam.NewCharacter = new SoldierRookie();
                soldierParam.NewCharacter = new SoldierWarrior();
                break;
            case Role.Rule:
                //对应类型
                soldierParam.NewCharacter = new SoldierRule();
                break;
            case Role.Sorcerer:
                soldierParam.NewCharacter = new SoldierSorcerer();
                break;         
            default:
                break;
        }

        if (soldierParam.NewCharacter == null)
            return null;

        //设置参数
        soldierParam.emWeapon = weapon;
        soldierParam.SpawnPosition = pos;
        soldierParam.Lv = lv;

        //建造者
        SoldierBuilder theBuilder = new SoldierBuilder();
        //设置参数
        theBuilder.SetBuildParam(soldierParam);

        BuilderDirector.m_GameObjectID = (int)emSolider;

        //产生
        BuilderDirector.Construct(theBuilder);

        return soldierParam.NewCharacter as ISoldier;

    }
    //选择 穿件面板的创建人物
    public override GameObject CreatRole(Role emType, int lv, Transform root, Vector3 v3)
    {

        IAssetFactory AssetFactory=PBDFactory.GetAssetFactory();
        GameObject ga= AssetFactory.LoadSoldier(((int)emType).ToString());
       //GameObject ga =Resources.Load<GameObject>("Role/" + (int)emType);

        return ga;
    }

    /// <summary>
    /// 创建怪物
    /// </summary>
    /// <param name="emEnemy"></param>
    /// <param name="emWepon"></param>
    /// <param name="SpawnPosition"></param>
    /// <returns></returns>
    public override IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWepon, Vector3 SpawnPosition)
    {
        EnemyBuildParam EnemyParam = new EnemyBuildParam();

        switch (emEnemy)
        {
            case ENUM_Enemy.Wolf:
                EnemyParam.NewCharacter = new EnemyWolf();
                break;
            case ENUM_Enemy.Pig:
                EnemyParam.NewCharacter = new EnemyPig();
                break;
            case ENUM_Enemy.WereWolf:
                EnemyParam.NewCharacter = new EnemyWereWolf();
                break;
            case ENUM_Enemy.Boss:
                break;
            default:
                break;
        }

        if(EnemyParam.NewCharacter==null)
        return null;

        EnemyParam.SpawnPosition = SpawnPosition;

        //参数
        EnemyBuilder theEnemyBuilder = new EnemyBuilder();
        theEnemyBuilder.SetBuildParam(EnemyParam);

        //产生
        BuilderDirector.Construct(theEnemyBuilder);
        return EnemyParam.NewCharacter as IEnemy; 

    }

}
