using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//游戏启动
public class GameLoop : MonoBehaviour
{
    //状态管理类
    SceneStateController m_SceneController = new SceneStateController();
    private void Awake()
    {
        PBaseDefenseGame.Instance.SetStateController(m_SceneController);

        //保证游戏入口不删除
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        //设置初始的场景
        m_SceneController.SetState(new StartScene(m_SceneController), "");
    }

    // Update is called once per frame
    void Update()
    {
        //状态的更新
        m_SceneController.StateUpdate();

        PBaseDefenseGame.Instance.Update();
    }
}
