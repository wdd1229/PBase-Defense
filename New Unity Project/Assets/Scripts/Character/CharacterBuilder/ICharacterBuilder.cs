using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_Weapon
{
	Null = 0,
	Gun = 1,
	Rifle = 2,
	Rocket = 3,
	Max,
}

// 建立角色時所需的參數
public abstract class ICharacterBuildParam
{
	public ENUM_Weapon emWeapon = ENUM_Weapon.Null;
	public ICharacter NewCharacter = null;
	public Vector3 SpawnPosition;
	public int AttrID;
	public string AssetName;
	public string IconSpriteName;
}
//组合 各个部件
public abstract class ICharacterBuilder  
{
	// 建立参数
	public abstract void SetBuildParam(ICharacterBuildParam theParam);
	// 加载Asset中的角色模型
	public abstract void LoadAsset(int GameObjectID);
	// 加入点击脚本
	public abstract void AddOnClickScript();
	// 加入武器
	public abstract void AddWeapon();
	// 加入AI
	public abstract void AddAI();
	// 角色能力
	public abstract void SetCharacterAttr();
	// 加入管理器
	public abstract void AddCharacterSystem(PBaseDefenseGame PBDGame);
}
