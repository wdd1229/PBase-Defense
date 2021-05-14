using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//策略
public abstract class IAttrStrategy : MonoBehaviour
{
	// 初始的数值
	public abstract void InitAttr(ICharacterAttr CharacterAttr);

	// 攻击加成
	public abstract int GetAtkPlusValue(ICharacterAttr CharacterAttr);

	// 取得减伤
	public abstract int GetDmgDescValue(ICharacterAttr CharacterAttr);


}
