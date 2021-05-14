using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 某一个事件类型
/// </summary>
public class IGameEventSubject 
{
    //观察集合
    private List<IGameEventObserver> m_Observers = new List<IGameEventObserver>();

    private System.Object m_Param = null;//参数

    //添加
    public void Attach(IGameEventObserver eventObserver)
    {
        m_Observers.Add(eventObserver);
    }
    //移除
    public void Remove(IGameEventObserver eventObserver)
    {
        m_Observers.Remove(eventObserver);
    }

    //通知
    public void Notify()
    {
        foreach (var item in m_Observers)
        {
            item.Update();
        }
    }

    //设置参数
    public virtual void SetParam(System.Object param)
    {
        m_Param = param;
    }
}
