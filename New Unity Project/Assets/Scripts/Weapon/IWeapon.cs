using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器的父级
/// </summary>
public abstract class IWeapon : MonoBehaviour
{
    //武器的类型
    protected ENUM_Weapon m_emWeaponType = ENUM_Weapon.Null;


    protected GameObject m_Game = null;//武器的模型
    protected ICharacter m_WeaponRoot = null;//武器的持有者

    protected ParticleSystem m_Particles;//特效
    protected AudioSource m_Audio;//音效

    // protected WeaponAttr m_WeaponAttr = null;		  	// 武器的能力

    public IWeapon() { }

    //指定使用的模型
    public void SetGameObj(GameObject ga)
    {
        m_Game = ga;

        //设置特效 也就是从模型上去查找 特效子物体  和查找音效
    }

    //设置持有者
    public void SetWeaponRoot(ICharacter Owner)
    {
        m_WeaponRoot = Owner;
    }

    //更新
    public void Update()
    {
        
    }

    //释放
    public void Reset()
    {
        
    }

    //攻击
    public void Fire(ICharacter terget)
    {
        //武器的发射 枪口位置的特效

        //子弹特效

        //播放音效

        //调用目标（terget）的受击方法
    }

    //给子类使用的方法 子类中逻辑也就是调用父类的播放特效和音效的方法

    //显示武器子弹的特效
    public abstract void DoShowBulletEffect(ICharacter target);
    //播放音效
    public abstract void DoShowSoundEffect();

}
