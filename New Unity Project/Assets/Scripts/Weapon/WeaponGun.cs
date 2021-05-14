using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : IWeapon
{
     public WeaponGun()
    {
        //构造中设置类型
        m_emWeaponType = ENUM_Weapon.Gun;
    }
    //武器子但特效
    public override void DoShowBulletEffect(ICharacter target)
    {
         //调用父类的特效方法
    }

    //音效
    public override void DoShowSoundEffect()
    {
         //调用父类的播放方法
    }

    



}
