using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关卡
/// </summary>
public abstract class IStageHandler 
{
    protected IStageHandler m_NextHandler = null;//下一个关卡
    protected IStageData m_StataeData = null;//关卡的数据

    protected IStageScore m_StatgeScore = null;//关卡的分数

    //设置下一关
    public IStageHandler SetNextHandler(IStageHandler NextHandler)
    {
        m_NextHandler = NextHandler;
        return m_NextHandler;
    }

    public abstract IStageHandler CheckStage();

    //更新
    public abstract void Update();
    //重置
    public abstract void Reset();
    //是否完成
    public abstract bool IsFinished();
    public abstract int LoseHeart();

}
