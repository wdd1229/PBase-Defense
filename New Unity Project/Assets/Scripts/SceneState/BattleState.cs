using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//战斗场景
public class BattleState : ISceneState
{
    public BattleState(SceneStateController controller) : base(controller)
    {
        this.StateName = "BattleState";
    }
    //开始
    public override void StateBegin()
    {

        //游戏初始
        PBaseDefenseGame.Instance.Initinal();



        //PBaseDefenseGame.Instance.BattSceneCreatRole();
        //创建角色命令


        PBaseDefenseGame.Instance.CreatPlayerCommmand();
    }


    //结束
    public override void StateEnd()
    {
        //PBDGame.Instance.Release()

    }

    //更新
    public override void StateUpdate()
    {
        //游戏逻辑
        //PBDGame.Instance.Upadte()
        //PBaseDefenseGame.Instance.Update();
        //游戏是否结束
        if (PBaseDefenseGame.Instance.ThisGameIsOVer())
        {
            //切换到主场景
            m_Controller.SetState(new MainMenuState(m_Controller), "MainMenuScene");
        }
    }
}
