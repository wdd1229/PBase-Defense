using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//主场景界面
public class MainMenuState : ISceneState
{
     public MainMenuState(SceneStateController Controller) : base(Controller)
    {
        this.StateName = "MainMenuState";
    }

    //开始
    public override void StateBegin()
    {
        Debug.Log("进入Menu");
        PBaseDefenseGame.Instance.CreatAndChooseInit();//创人选人的初始

        //找到开始按钮
        //Button StartBtn = GameObject.Find("StartBtn").GetComponent<Button>();
        //if (StartBtn != null)
        //{
        //    //添加执行方法
        //    StartBtn.onClick.AddListener(() =>
        //    {
        //        OnStartGameBtnClick();
        //    });
        //}
    }

    //切换状态 到战斗场景
    private void OnStartGameBtnClick()
    {
        m_Controller.SetState(new BattleState(m_Controller), "BattleScene");
    }

}
