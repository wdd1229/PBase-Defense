
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 一般的关卡 数据
/// </summary>
public class NormalStageData : IStageData
{
    float CoolDown = 0;//生成角色的间隔时间

    private Vector3 m_SpawnPosition = Vector3.zero;	// 出生點

    //可创建关卡的敌人类 StageData 决定角色类型 武器类型 
    class StageData
    {
        public ENUM_Enemy emEnemy = ENUM_Enemy.Null;
        public ENUM_Weapon emWeapon = ENUM_Weapon.Null;
        public bool bBorn = false;
        public StageData(ENUM_Enemy emEnemy,ENUM_Weapon emWeapon)
        {
            this.emEnemy = emEnemy;
            this.emWeapon = emWeapon;
        }
    }
    //List<StageData> m_StageData //要生成的敌人
    private List<StageData> m_StageData = new List<StageData>();

    //添加敌人方法 m_StageData.Add
    public void AddStageData(ENUM_Enemy emEnemy,ENUM_Weapon emWeapon,int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            m_StageData.Add(new StageData(emEnemy, emWeapon));
        }
    }

    bool iSTrue = false;

    //  出生点  
    public NormalStageData(Vector3 SpawnPosition)
    {
        this.m_SpawnPosition = SpawnPosition;
        
    }



  
    //重置
    public override void Reset()
    {
        foreach (StageData pData in m_StageData)
            pData.bBorn = false;
    }
    //更新
    public override void Update()
    {
        if (m_StageData.Count == 0)
            return;


        foreach (StageData item in m_StageData)
        {
            if (item.bBorn == false)
            {
                Debug.Log("产生怪物");
                //产生怪物
                item.bBorn = true;
                ICharacterFactory factory = PBDFactory.GetCharacterFactory();

                factory.CreateEnemy(item.emEnemy, ENUM_Weapon.Null,new Vector3(UnityEngine.Random.Range(-10,10),0, UnityEngine.Random.Range(-10, 10)));
                
            }
        }
    }

    //是否完成关卡
    public override bool IsFinished()
    {
        return iSTrue;
    }
}
