
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏关卡系统
/// </summary>
public class StageSystem : IGameSystem
{
	public int m_EnemyKilledCount = 0;//敌方阵亡数

	public int m_NowStageLv = 1;//当前的关卡
	public IStageHandler m_NowStageHandler = null;//当前关卡
	public IStageHandler m_RootStageHandler = null;//下一个管阿卡

	private bool m_bCreateStage = false;//是否创建关卡

	public StageSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
	{
		 
		Initialize();

		m_NowStageHandler = m_RootStageHandler;
		m_NowStageLv = 1;



	}

	//初始
	public override void Initialize()
	{
		//base.Initialize();
		//设定关卡
		InitializeStageData();
		//指定第一关

		//注册关卡的观察者
	}

	//设定关卡
	public void InitializeStageData()
	{
		//当前关卡有下一个关卡 不需要建立
		if (m_RootStageHandler != null)
			return;

		NormalStageData StageData = null; // 一般关卡数据 也就是要生成多少怪物
		IStageScore StageScore = null; // 分数
		IStageHandler NewStage = null;

		//初始点
		StageData = new NormalStageData(Vector3.zero);

		StageData.AddStageData(ENUM_Enemy.Wolf, ENUM_Weapon.Null, 3);//添加怪物数据
		StageScore = new StageScoreEnemyKilledCount(3, this);//指定通关条件 也就是击杀数达到
		NewStage = new NormalStageHandler(StageScore, StageData);

		//设为起始关卡
		m_RootStageHandler = NewStage;


		// 第2關
		//StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		//StageData.AddStageData(ENUM_Enemy.Elf, ENUM_Weapon.Rifle, 3);
		//StageScore = new StageScoreEnemyKilledCount(6, this);
		//NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));
	}

	Vector3 AttackPosition()
	{
		//找到攻击点
		return Vector3.zero;
	}

	//出省点
	private Vector3 GetSpawnPosition()
	{
		//查找对应类型怪物的初始点
		return Vector3.zero;
	}

	//释放
	public override void Release()
	{
		base.Release();
	}

	//更新
	public override void Update()
	{
		Debug.Log("关卡");
		//更新关卡
		m_NowStageHandler.Update();

		//是否要切换关卡
		 
	}



}
