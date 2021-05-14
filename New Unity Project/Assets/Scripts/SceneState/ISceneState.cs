using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneState  
{
    //名称
    private string stateName = "ISceneState";
    public string StateName
    {
        get
        {
            return stateName;
        }
        set
        {
            stateName = value;
        }
    }

    //管理
    protected SceneStateController m_Controller = null;

    //建造者
    public ISceneState(SceneStateController controller)
    {
        m_Controller = controller;
    }

    //开始
    public virtual void StateBegin()
    {

    }

    //更新
    public virtual void StateUpdate()
    {

    }

    //结束
    public virtual void StateEnd()
    {

    }


}
