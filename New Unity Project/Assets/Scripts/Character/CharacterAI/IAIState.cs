using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AI状态的父级 也就是IDle Move Att的父级
/// </summary>
public abstract class IAIState  
{
    protected ICharacterAI m_CharacterAI = null; // 角色AI(狀態的擁有者
    public IAIState()
    { }

    // 设置拥有者
    public void SetCharacterAI(ICharacterAI CharacterAI)
    {
        m_CharacterAI = CharacterAI;
    }

    // 攻击目标哦
    public virtual void SetAttackPosition(Vector3 AttackPosition)
    { }

    // 更新
    public abstract void Update(List<ICharacter> Targets);

    // 目標被移除
    public virtual void RemoveTarget(ICharacter Target)
    { }
}
