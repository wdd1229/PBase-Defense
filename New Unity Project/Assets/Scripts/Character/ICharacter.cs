using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//角色
public abstract class ICharacter 
{
    protected string m_Name;//角色的名字

    protected GameObject m_GameObject = null;//使用的模型
    protected NavMeshAgent m_NavAgent = null;//角色的寻路组件
    protected AudioSource m_Audio = null;//角色的声音

    protected string m_AssetName = "";//模型的名称

    protected int m_AttrID = 0;//用到的属性的编号

    protected bool m_IsKilled = false;//是否已经死亡

    private IWeapon m_Weapon = null;//使用的武器
    protected ICharacterAttr m_Attribute = null;//数值

    protected ICharacterAI m_AI = null;//角色的AI

    public ICharacter() { }

    //设置模型
    public void SetGameObjec(GameObject game)
    {
        m_GameObject = game;
        m_NavAgent = game.GetComponent<NavMeshAgent>();//拿到寻路组件
        m_Audio = game.GetComponent<AudioSource>();//拿到声音组件
    }

    //对外提供的获取模型接口
    public GameObject GetGameObject()
    {
        return m_GameObject;
    }

    // 取得属性ID
    //public int GetAttrID()
    //{
    //    return m_AttrID;
    //}

    //更新
    public void Update()
    {
        //判断是否死亡 死亡则移除
        if (m_IsKilled)
        {

        }
    }

    //移动到指定位置
    public void MoveTo(Vector3 vector)
    {
        m_NavAgent.SetDestination(vector);
    }

    //攻击目标
    public void Attack(ICharacter Target)
    {
        //设置武器的攻击加成
        SetWeaponAtkValue(/*m_Attribute.GetAtkValue() 调用数值类里的加成*/);

        //攻击
        WeaponAttakTarget(Target);

        //播放攻击动作
        //获取人物上的播放动画脚本 调用方法
        //m_GameObject.GetComponent<>().PlayAtk();

        //看向目标 目标人物位置减去当前人物位置
        m_GameObject.transform.forward = Target.GetPos() - GetPos();
    }

    public void SetWeapon(/* 参数为武器*/)
    {
        //给属性赋值

        //调用武器方法 设置武器的拥有者 参数this


    }

    public int GetAtkValue()
    {
        //武器的攻击力加上 角色数值中的加成
        return  0 /* 武器中的攻击力加 武器的额外加成*/;
    }

    //拿到位置
    public Vector3 GetPos()
    {
        return m_GameObject.transform.position;
    }

    public void SetWeaponAtkValue(/*int value*/)
    {
        //设置攻击力加成
        //m_Weapon.SetAtKValue(value);
    }

    //武器攻击
    public void WeaponAttakTarget(ICharacter target)
    {
        //调用m_Weapon 的攻击方法 参数为target
    }

    // 被其他角色攻击
    public abstract void UnderAttack(ICharacter Attacker);

    //播放音效
    public void PlaySound(string ClipName)
    {

    }

    // 執行Visitor
    public virtual void RunVisitor(/*ICharacterVisitor Visitor*/)
    {

    }

    // 取得Asset名稱
    public string GetAssetName()
    {
        return m_AssetName;
    }

    //  Unity模型
    public void SetGameObject(GameObject theGameObject)
    {
        m_GameObject = theGameObject;
        m_NavAgent = m_GameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_Audio = m_GameObject.GetComponent<AudioSource>();
    }

    // 取得 ID
    public int GetAttrID()
    {
        return m_AttrID;
    }

    public virtual void SetCharacterAttr(ICharacterAttr CharacterAttr)
    {
        
        // 設定
        m_Attribute = CharacterAttr;
        m_Attribute.InitAttr();

        // 設定移動速度
        m_NavAgent.speed = m_Attribute.GetMoveSpeed();
        //Debug.Log ("設定移動速度:"+m_NavAgent.speed);

        // 名稱
        m_Name = m_Attribute.GetAttrName();
    }
}
