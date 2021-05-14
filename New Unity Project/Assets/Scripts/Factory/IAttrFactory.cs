using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ENUM_Attr{
	Player,Monster,
}
public abstract class IAttrFactory : MonoBehaviour
{

	// 取得Soldier的數值
	public abstract SoldierAttr GetSoldierAttr(int AttrID);

	// 取得Soldier的數值:有字首字尾的加乘
	public abstract SoldierAttr GetEliteSoldierAttr(ENUM_Attr emType, int AttrID, SoldierAttr theSoldierAttr);

	// 取得Enemy的數值
	public abstract EnemyAttr GetEnemyAttr(int AttrID);

	// 取得武器的數值
	public abstract WeaponAttr GetWeaponAttr(int AttrID);

	// 取得加乘用的數值
	public abstract AdditionalAttr GetAdditionalAttr(int AttrID);
}
