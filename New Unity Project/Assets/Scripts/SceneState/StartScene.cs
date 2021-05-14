using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//初始
public class StartScene : ISceneState
{
    public StartScene(SceneStateController Controler) : base(Controler)
    {
        this.StateName = "StartState";
    }

    //开始
    public override void StateBegin()
    {
        //初始化
     
    }

    public override void StateUpdate()
    {
        //调用管理中的方法 切换状态
        m_Controller.SetState(new MainMenuState(m_Controller),"MainMenuScene");
    }
}
