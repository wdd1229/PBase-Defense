using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//加成数值
public class AdditionalAttr
{
    private int m_Strength;//力量
    private int m_Agility;//敏捷
    private string m_Name;//名字

    public AdditionalAttr(int Strength,int Agility,string Name)
    {
        m_Strength = Strength;
        m_Agility = Agility;
        m_Name = Name;
    }

    //获取力量
    public int GetStrength()
    {
        return m_Strength;
    }
    //获取敏捷
    public int GetAgility()
    {
        return m_Agility;
    }
}

//角色数值的装饰着   子类继承之后对数值进行操作
public class BaseAttrDecorator : BaseAttr
{
    protected BaseAttr m_Component;//被装饰 对象
    protected AdditionalAttr m_AdditionialAttr;//额外加成

    //设置装饰目标
    public void SetComponent(BaseAttr theCom)
    {
        m_Component = theCom;
    }

    //设定额外加成
    public void SetAdditionalAttr(AdditionalAttr theAdditionalAttr)
    {
        m_AdditionialAttr = theAdditionalAttr;
    }

    public override int GetMaxHp()
    {
        return m_Component.GetMaxHp();
    }

    public override float GetMoveSpeed()
    {
        return m_Component.GetMoveSpeed();
    }

    public override string GetAttrName()
    {
        return m_Component.GetAttrName();
    }
}
