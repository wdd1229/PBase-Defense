using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通过Builder创建  建造者
/// </summary>
public class CharacterBuilderSystem : IGameSystem
{
    public int m_GameObjectID = 0;
    public CharacterBuilderSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    { }

    //初始
    public override void Initialize()
    { }

    //更新
    public override void Update()
    { }


	// 建立 的方法  
	public void Construct(ICharacterBuilder theBuilder)
	{
		// 利用Builder创建各部份加入Product中
		theBuilder.LoadAsset(++m_GameObjectID);//加载资源
		theBuilder.AddOnClickScript();//添加点击脚本
		theBuilder.AddWeapon();//设置武器
		theBuilder.SetCharacterAttr();
		theBuilder.AddAI();//角色AI

		// 加入管理器內
		theBuilder.AddCharacterSystem(m_PBDGame);
	}
}
