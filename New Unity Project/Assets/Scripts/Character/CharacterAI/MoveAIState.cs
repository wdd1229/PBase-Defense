using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 移动Ai
/// </summary>
public class MoveAIState : IAIState
{
	Vector3 m_AttackPosition = Vector3.zero;
	bool m_bOnMove = false; //是否可以移动
	//要攻击的目标
	public override void SetAttackPosition(Vector3 AttackPosition)
	{
		m_AttackPosition = AttackPosition;
	}

	/// <summary>
	/// 更新
	/// </summary>
	/// <param name="Targets"></param>
	public override void Update(List<ICharacter> Targets)
	{
		//判断有无目标 
		//有 改为待机状态 m_CharacterAI.ChangeAIState( new IdleAIState() );

		//可以移动时  
		//先判断和目标点的位置 是否到达

		//通过角色中的MoveTo 移动 m_CharacterAI.MoveTo
	}
}
