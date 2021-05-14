using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 观察者 Ui观察角色阵亡事件
/// </summary>
public class SoldierKilledObserverUI : IGameEventObserver
{
    //事件的类型
    private SoldierKilledSubject Subject = null;

    //具体的UI
    //private SoldierInfoUi InfoUi=null

    public SoldierKilledObserverUI(/*SoldierInfoUi INfoui*/)
    {
        //InfoUi= INfoui
    }


    public override void SetSubject(IGameEventSubject newSubject)
    {
        Subject = newSubject as SoldierKilledSubject;
    }

    public override void Update()
    {
        //通知具体UI界面 更新
        //参数为具体阵亡的对象 也就 在m_Subject中存储的param
        //SoldierInfoUi.Refresh(m_Subject.GetSoldier());
    }
}
