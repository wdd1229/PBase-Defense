using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttrStrategy : IAttrStrategy
{
	public override void InitAttr(ICharacterAttr CharacterAttr)
	{
		 
	}

	public override int GetAtkPlusValue(ICharacterAttr CharacterAttr)
	{
		 
		EnemyAttr theEnemyAttr = CharacterAttr as EnemyAttr;
		if (theEnemyAttr == null)
			return 0;

		// 攻击加成
		int RandValue = UnityEngine.Random.Range(0, 100);
		if (theEnemyAttr.GetCritRate() >= RandValue)
		{
			theEnemyAttr.CutdownCritRate();     // 減少暴击率
			return theEnemyAttr.GetMaxHP() * 5;     // 血量的5倍值
		}
		return 0;
	}
	//减少伤害
	public override int GetDmgDescValue(ICharacterAttr CharacterAttr)
	{
		// 沒有減傷
		return 0;
	}
}
