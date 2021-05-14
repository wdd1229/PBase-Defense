using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 角色的管理类
/// </summary>
public class CharacterSystem : IGameSystem
{
    private List<ICharacter> m_Soldiers = new List<ICharacter>();//角色库
    private List<ICharacter> m_Enemys = new List<ICharacter>();//敌人库

    public CharacterSystem(PBaseDefenseGame PBDgame) : base(PBDgame)
    {
        //调用初始化方法
        Initialize();

        //注册事件

    }
    //初始
    public override void Initialize()
    {
        base.Initialize();
    }
    //释放
    public override void Release()
    {
        base.Release();
    }
    //更新
    public override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// 添加角色
    /// </summary>
    public void AddSoldier(ISoldier soldier)
    {

    }

    /// <summary>
    /// 移除角色
    /// </summary>
    public void RemoveSoldier(ISoldier soldier)
    {

    }

    // 增加敌人
    public void AddEnemy(IEnemy theEnemy)
    {
        m_Enemys.Add(theEnemy);
    }

    // 移除敌人
    public void RemoveEnemy(IEnemy theEnemy)
    {
       
    }

    //移除可以删除的角色
    public void RemoveCharacter()
    {
        RemoveCharacter(m_Soldiers, m_Enemys, ENUM_GameEvent.SoldierKilled);
        RemoveCharacter(m_Enemys, m_Soldiers, ENUM_GameEvent.EnemyKilled);

    }

    //移除 角色
    public void RemoveCharacter(List<ICharacter> Characters, List<ICharacter> Opponents, ENUM_GameEvent type)
    {
        // 分別取得可以移除及存活的角色

        // 判断是否陣亡
        // 是否可以移除

        //移除 然后释放资源

    }

    //更新角色
    public void UpdateCharacter()
    {
        //遍历集合 
        //调用角色中的Update()
    }


}
