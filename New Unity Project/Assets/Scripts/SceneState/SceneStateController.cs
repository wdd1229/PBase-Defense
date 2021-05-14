using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//场景状态管理
public class SceneStateController  
{
    private ISceneState m_State;
    private bool m_RunBegin = false;

    //设置状态
    public void SetState(ISceneState State,string LoadSceneName)
    {
        m_RunBegin = false;

        //加载场景
        LoadScene(LoadSceneName);

        //前一个状态结束
        if (m_State != null)
        {
            m_State.StateEnd();
        }

        //设置当前状态
        m_State = State;
    }

    void LoadScene(string LoadSceneName)
    {
        if (LoadSceneName == null || LoadSceneName.Length == 0)
            return;
        //Debug.Log(LoadSceneName);
        //切换场景
        Application.LoadLevel(LoadSceneName);
    }

    //更新
    public void StateUpdate()
    {
        //判断是否正在加载场景
        if (Application.isLoadingLevel)
        {
            return;
        }

       //判断是否要切换
        if(m_State!=null && m_RunBegin == false)
        {
            //新场景开始
            m_State.StateBegin();
            m_RunBegin = true;
        }

        if (m_State != null)
        {
            //场景的更新
            m_State.StateUpdate();
        }

    }
}
