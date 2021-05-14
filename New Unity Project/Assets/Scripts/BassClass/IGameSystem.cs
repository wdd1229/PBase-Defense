using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 所有系统的父类
/// </summary>
public class IGameSystem  
{
    protected PBaseDefenseGame m_PBDGame = null;

    public IGameSystem(PBaseDefenseGame PBDgame)
    {
        m_PBDGame = PBDgame;
    }
    //初始化
    public virtual void Initialize() { }

    //释放
    public virtual void Release() { }

    //更新
    public virtual void Update() { }
}
