using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关卡数据
/// </summary>
public abstract class IStageData 
{
    //更新
    public abstract void Update();
    //是否完成条件
    public abstract bool IsFinished();
    //重置
    public abstract void Reset();
}
