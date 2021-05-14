using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 游戏事件的类型
public enum ENUM_GameEvent
{
    Null = 0,
    EnemyKilled = 1,// 敵方單位陣亡
    SoldierKilled = 2,// 玩家單位陣亡
    SoldierUpgate = 3,// 玩家單位升級
    NewStage = 4,// 新關卡
}
/// <summary>
/// 游戏事件系统
/// </summary>
public class GameEventSystem : IGameSystem
{
    //事件库
    private Dictionary<ENUM_GameEvent, IGameEventSubject> m_GameEvents = new Dictionary<ENUM_GameEvent, IGameEventSubject>();

    public GameEventSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        //初始
        Initialize();
    }
    //释放
    public override void Release()
    {
        //清空
        m_GameEvents.Clear();
    }

    //为某一个事件类型注册观察者
    public void RegisterObserver(ENUM_GameEvent emGameEvent, IGameEventObserver observer)
    {
        //先再库中查找是否有该类型的事件 有就返回 没有就创建对应的返回
        IGameEventSubject subject = GetGameEventSubject(emGameEvent);
    }

    /// <summary>
    /// 库中查找是否有该类型的事件 有就返回 没有就创建对应的返回
    /// </summary>
    /// <param name="emGameeEvent"></param>
    /// <returns></returns>
    public IGameEventSubject GetGameEventSubject(ENUM_GameEvent emGameeEvent)
    {
        //判断是否存在
        if (m_GameEvents.ContainsKey(emGameeEvent))
        {
            return m_GameEvents[emGameeEvent];
        }

        //如果没有就创建出对应类型的 
        IGameEventSubject newSuject = null;
        switch (emGameeEvent)
        {
            case ENUM_GameEvent.Null:

                break;
            case ENUM_GameEvent.EnemyKilled:

                break;
            case ENUM_GameEvent.SoldierKilled:

                break;
            case ENUM_GameEvent.SoldierUpgate:
                break;
            case ENUM_GameEvent.NewStage:
                break;
            default:
                return null;
        }

        //加入库中
        m_GameEvents.Add(emGameeEvent, newSuject);
        return newSuject;
    }

    /// <summary>
    /// 通知一个类型的事件进行更新 参数传递
    /// </summary>
    /// <param name="emGameEvent"></param>
    /// <param name="param"></param>
    public void NotifySubject(ENUM_GameEvent emGameEvent,Object param)
    {
        //判断 是否存在
        if (m_GameEvents.ContainsKey(emGameEvent) == false)
        {
            return;
        }
        else
        {
            //存在
            m_GameEvents[emGameEvent].SetParam(param);//设置参数
        }
    }

}
