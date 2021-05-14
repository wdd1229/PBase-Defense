using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//角色数值
public abstract class ICharacterAttr 
{
    protected BaseAttr m_BaseAttr;//数值

    protected int NowHp = 0;//当前hp

    protected IAttrStrategy m_AttStrategy = null;//数值的计算策略

    public ICharacterAttr() { }

    //设置数值
    public void SetBaseAttr(BaseAttr BaseAttr)
    {
        m_BaseAttr = BaseAttr;
    }
    // 设置计算策略
    public void SetAttStrategy(IAttrStrategy theAttrStrategy)
    {
        m_AttStrategy = theAttrStrategy;
    }

    // 取得被武器攻击的伤害
    public void CalDmgValue(ICharacter Attacker)
    {
        // 取得武器攻击力


        // 获得减伤

        // 当前血量减去伤害
    }

    // 最大HP
    public virtual int GetMaxHP()
    {
        return m_BaseAttr.GetMaxHp();
    }

    //  速度
    public virtual float GetMoveSpeed()
    {
        return m_BaseAttr.GetMoveSpeed();
    }

    // 取得數值名稱
    public virtual string GetAttrName()
    {
        return m_BaseAttr.GetAttrName();
    }

    // 初始角色數值
    public virtual void InitAttr()
    {
        m_AttStrategy.InitAttr(this);

        //刚开始将当前血量设置为最大值
    }
}
