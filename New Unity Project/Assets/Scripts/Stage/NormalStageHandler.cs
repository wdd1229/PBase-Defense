using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 一般关卡
/// </summary>
public class NormalStageHandler : IStageHandler
{
    // 设置分數及关卡数据
    public NormalStageHandler(IStageScore StateScore, IStageData StageData)
    {
        m_StatgeScore = StateScore;
        m_StataeData = StageData;
    }

    //
    public override IStageHandler CheckStage()
    {
        //判断分数是否足够

        //是否为最后一关

        //确认下一个关卡 下一个关卡的CheckStage
        throw new System.NotImplementedException();

        
    }

    //更新
    public override void Update()
    {

        m_StataeData.Update();
    }

    //复原
    public override void Reset()
    {
        m_StataeData.Reset();
    }

    //判断完成
    public override bool IsFinished()
    {
        return m_StataeData.IsFinished();
    }

    //损失的生命值
    public override int LoseHeart()
    {
        return 1;
    }

}
