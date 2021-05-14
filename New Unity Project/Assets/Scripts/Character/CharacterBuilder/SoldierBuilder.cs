using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 创建角色时所需的参数
/// </summary>
public class SoldierBuildParam : ICharacterBuildParam
{
	public int Lv = 0;
	public SoldierBuildParam()
	{
	}
}

/// <summary>
/// 创建角色 各部分的建立
/// </summary>
public class SoldierBuilder : ICharacterBuilder
{
	//角色所需参数类
	private SoldierBuildParam m_BuildParam = null;

	public override void SetBuildParam(ICharacterBuildParam theParam)
	{
		m_BuildParam = theParam as SoldierBuildParam;
	}

	/// <summary>
	/// 加载模型
	/// </summary>
	/// <param name="GameObjectID"></param>
	public override void LoadAsset(int GameObjectID)
	{
		//加载人物模型
		Debug.Log("加载加载人物模型加载人物模型");

		IAssetFactory assetFactory = PBDFactory.GetAssetFactory();
		GameObject PlayerGameObject = assetFactory.LoadSoldier(GameObjectID.ToString());

		PlayerGameObject.name = ((Role)GameObjectID).ToString();
		PlayerGameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
		m_BuildParam.NewCharacter.SetGameObjec(PlayerGameObject);

	}

	/// <summary>
	/// 给人物添加点击脚本
	/// </summary>
	public override void AddOnClickScript()
	{
		//m_BuildParam.NewCharacter.GetGameObject().AddComponent<>();


	}

	// 加入武器
	public override void AddWeapon()
	{
		//通过PBDG拿到武器工厂
		 //将武器设置给角色

	}

	public override void SetCharacterAttr()
	{
		//设置角色的数值 攻击力等

		//设置策略

		//设置等级

		//给角色需要的参数类在m_BuildParam 设置这些

	}

	// 加入AI
	public override void AddAI()
	{
		//创建Ai类
		//在m_BuildParam 类中设置Ai

	}

	// 加入管理器
	public override void AddCharacterSystem(PBaseDefenseGame PBDGame)
	{
		//通过PBDGame 调用CharacterSystem 方法将 角色添加到列表中 

		PBaseDefenseGame.Instance.SetCharacterConGameObj(m_BuildParam.NewCharacter.GetGameObject());
	}

	

}