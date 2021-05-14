using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色的AI
/// </summary>
public abstract class ICharacterAI  
{
    //角色 也就是拥有者
    protected ICharacter m_Character = null;
    //攻击距离
    protected float m_AttackRange = 2;

    //状态 Idle Move Att
    protected IAIState m_AIState = null;

    public ICharacterAI(ICharacter Character)
    {
        m_Character = Character;
        //m_AttackRange = Character.GetAttackRange();
    }

    // 更改AI的状态
    public virtual void ChangeAIState(IAIState NewAIState)
    {
        m_AIState = NewAIState;
        //m_AIState.SetCharacterAI(this);//设置拥有者


    }

    //攻击
    public virtual void Attack(ICharacter target)
    {

        //计时  攻击间隔时间  

        //攻击方法
        m_Character.Attack(target);
    }

    /// <summary>
    /// 判断攻击距离 
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool TargetInAttackRange(ICharacter target)
    {
        //通过 Vector3.Distance 和GetPos获取攻击者 和收集者位置 算出距离

        //判断攻击距离
        return true;
    }

    // 是否可以攻擊Heart
    public abstract bool CanAttackHeart();

    //移动 阵亡 获取位置等 都可以调用 Character中的方法获得


}
