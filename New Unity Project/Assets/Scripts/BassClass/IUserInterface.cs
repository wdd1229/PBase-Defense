using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 界面的父级
/// </summary>
public class IUserInterface 
{
   //使用PBDG实现系统和界面之间的交互
    protected PBaseDefenseGame m_PBDGame = null;

    //根
    protected GameObject m_RootUI = null;

    private bool m_Active = true;//显示隐藏
    public IUserInterface(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }



    public virtual void Show()
    {
        Debug.Log("物体显示 变量变为true");
        //物体显示 变量变为true
        m_RootUI.SetActive(true);
        m_Active = true;
    }

    public virtual void Hide()
    {
        //物体隐藏 变量变为false
        m_RootUI.SetActive(false);
        m_Active = false;
    }

    //初始化
    public virtual void Initialize() { }

    //释放
    public virtual void Release() { }

    //更新
    public virtual void Update() { }
}
