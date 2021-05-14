using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌人的类型
public enum ENUM_Enemy
{
    Null=0,
    Wolf=1,//狼
    Pig=2,//猪
    WereWolf=3,//狼人
    Boss=4,//伏兵
}
//敌人的角色
public abstract class IEnemy : ICharacter
{
    //类型
    protected ENUM_Enemy m_emEnemyType = ENUM_Enemy.Null;

    public IEnemy()
    { }

    /// <summary>
    /// 被攻击
    /// </summary>
    /// <param name="Attacker"></param>
    public override void UnderAttack(ICharacter Attacker)
    {
        //调用父类属性数值类 计算伤害
        
        //音效

        //特效

        //是否阵亡
    }

    //播放音效
    public abstract void PlayAaudio();

    //特效
    public abstract void PlayEffect();
}
