using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 可被共享的基本角色数值 父级
/// </summary>
public abstract class BaseAttr  
{
    public abstract int GetMaxHp();//最大血量
    public abstract float GetMoveSpeed();//最大移动速度
    public abstract string GetAttrName();//名称 
}

//角色数值
public class CharacterBaseAttr : BaseAttr
{
    private int m_MaxHp;
    private float m_MoveSpeed;
    private string m_AttrName;

    public CharacterBaseAttr(int Hp,float Speed,string Name)
    {
        m_MaxHp = Hp;
        m_MoveSpeed = Speed;
        m_AttrName = Name;
    }
    //获取名称
    public override string GetAttrName()
    {
        return m_AttrName;
    }
    //获取最大血量
    public override int GetMaxHp()
    {
       return m_MaxHp;
    }
    //获取最大速度
    public override float GetMoveSpeed()
    {
        return m_MoveSpeed;
    }
}

//敌方角色数值
public class EnemyBaseAttr : CharacterBaseAttr
{
    public int m_InitCritRate;//暴击率

    public EnemyBaseAttr(int hp,float speed,string name,int Crit) : base(hp, speed, name)
    {
        m_InitCritRate = Crit;
    }
    //获取暴击率
    public virtual int GetInitCritRate()
    {
        return m_InitCritRate;
    }
}
