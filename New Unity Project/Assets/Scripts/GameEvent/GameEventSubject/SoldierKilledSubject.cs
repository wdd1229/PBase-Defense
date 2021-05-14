using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色死亡的事件
/// </summary>
public class SoldierKilledSubject : IGameEventSubject
{
    private int KilledCount = 0;//数量

    private ISoldier m_Soldier = null;//角色对象

    public SoldierKilledSubject() { }

    /// <summary>
    /// 拿到对象
    /// </summary>
    /// <returns></returns>
    public ISoldier GetSoldier()
    {
        return m_Soldier;
    }

    //通知角色死亡  这里参数为死亡的玩家 也就是Soldier对象
    public override void SetParam(System.Object param)
    {
        base.SetParam(param);
        m_Soldier = param as ISoldier;

        KilledCount++;//阵亡数量计数

        //通知观察者
        Notify(); //会调用到 观察者的Update 方法
    }


}
