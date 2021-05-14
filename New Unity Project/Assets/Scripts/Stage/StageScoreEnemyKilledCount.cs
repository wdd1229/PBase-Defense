using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 根据敌人的阵亡数 判断是否完成关卡
/// </summary>
public class StageScoreEnemyKilledCount : IStageScore
{
    public int m_KilledCount = 0;
    public StageSystem m_StageSystem = null;

    public StageScoreEnemyKilledCount(int killCount,StageSystem sys)
    {

        m_KilledCount = killCount;
        m_StageSystem = sys;
    }

    //确定关卡是否完成 判断数量
    public override bool CheckScore()
    {
        //从StageSystem中拿到击杀数 和通关数比较
        return false;
    }


}
