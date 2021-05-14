using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 角色类型
public enum ENUM_Soldier
{
    Null = 0,
    Rookie = 1, // 新兵
    Sergeant = 2,   // 中士
    Captain = 3,    // 上尉
    Captive = 4,    // 俘兵
    Max,
}
/// <summary>
/// 角色
/// </summary>
public abstract class ISoldier : ICharacter
{
    //类型
	protected Role m_emSoldier = Role.Null;

    public ISoldier()
    {
    }
    // 被武器攻击
    public override void UnderAttack(ICharacter Attacker)
    {
        //调用数值计算伤害
        m_Attribute.CalDmgValue(Attacker);

        //判断血量 
        //从m_Attribute中拿到当前血量 判断是否小于等于0

        //音效 特效 死亡
        
    }

    // 播放音效
    public abstract void PlayAaudio();

    // 播放特效
    public abstract void PlayEffect();
    

    // 執行Visitor
    public override void RunVisitor(/*ICharacterVisitor Visitor*/)
    {

    }

}
