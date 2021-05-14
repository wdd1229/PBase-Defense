using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家的AI
/// </summary>
public class SoldierAI : ICharacterAI
{
	public SoldierAI(ICharacter Character) : base(Character)
	{
		//设置 人物的初始状态
		ChangeAIState(new MoveAIState());

	
	}

	//是否可以攻击
	public override bool CanAttackHeart()
	{
		return false;
	}
}
