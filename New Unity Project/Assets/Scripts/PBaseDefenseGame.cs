using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//系统之间 系统和Ui之间的通信
public class PBaseDefenseGame 
{
    //单例
    private static PBaseDefenseGame _instance;
    public static PBaseDefenseGame Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PBaseDefenseGame();
            }
            return _instance;
        }
    }

    SceneStateController stateController = null;//用于场景的切换

    private bool m_bGameOver = false;//场景的状态控制 游戏结束时回到MainMenu场景

    private CharacterSystem m_CharacterSystem = null;//角色管理系统

    private GameEventSystem GameEventSystem = null;//游戏的事件系统

    private CampSystem campSystem = null;//兵营系统

    private StageSystem stageSystem = null;//关卡系统

    private static ICharacterFactory m_CharacterFactory = null;//角色工厂

    private RoleManager roleManager = null;//选人创人时 人物

    CharacterControlSystem characterControlSystem = null;//控制人物系统

    CommondSystem commondSystem = null;//命令系统

     

    //UI
    //private CampInfoUI campInfoUI = null;//兵营界面

    private CreatRoleUI creatRoleUI = null;//创人界面

    private ChooseRoleUI chooseRoleUI = null;//选人界面

    private PlayerInfoUI playerInfoUI = null;//玩家信息

    public void CreatAndChooseInit()
    {
        roleManager = new RoleManager(this);

        creatRoleUI = new CreatRoleUI(this);//角色创建UI
        chooseRoleUI = new ChooseRoleUI(this); //选人界面

    }

    //初始
    public void Initinal()
    {
        //场景状态控制
        m_bGameOver = false;

        GameEventSystem = new GameEventSystem(this);//游戏事件系统

        m_CharacterSystem = new CharacterSystem(this);//角色管理系统

        campSystem = new CampSystem(this);//兵营

        stageSystem = new StageSystem(this);//关卡

        commondSystem = new CommondSystem(this);//主角的命令管理类

        characterControlSystem = new CharacterControlSystem(this);//主角的控制类

        //UI
        //campInfoUI = new CampInfoUI(this);//兵营UI
        playerInfoUI = new PlayerInfoUI(this);//玩家属性

        //注册游戏事件系统
        ResigerGameEvent();
    }

    //注册游戏事件系统
    public void ResigerGameEvent()
    {


        //注册事件
        //GameEventSystem.RegisterObserver(ENUM_GameEvent.SoldierKilled, new SoldierKilledObserverUI(this));
    }

    //注册事件
    public void RegisterGameEvent(ENUM_GameEvent emGameEvent, IGameEventObserver Observer)
    {
        GameEventSystem.RegisterObserver(emGameEvent, Observer);
    }

    //更新
    public void Update()
    {
        //检测玩家输入
        InputProcess();

        if(roleManager!=null)
        roleManager.Update();

        if(commondSystem!=null)
        commondSystem.Update();

        if (playerInfoUI != null)
            playerInfoUI.Update();

        if (characterControlSystem != null)
            characterControlSystem.Update();

        if (stageSystem != null)
            stageSystem.Update();

        //调用各个系统和 界面的 Update
        //campSystem.Update();
    }

    //检测玩家输入
    public void InputProcess()
    {
        if (Input.GetMouseButtonUp(0) == false)
            return;
        //发送射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (var item in hits)
        {
            Debug.Log("执行脚本上onclick方法");

            //获取物体上的点击脚本
            CampOnClick campOnClick = item.transform.gameObject.GetComponent<CampOnClick>();
            if (campOnClick != null)
            {
                //执行脚本上onclick方法
                campOnClick.OnClick();
                return;
            }

            //PlayerInfoOnClick playerInfoOnClick = item.transform.gameObject.GetComponent<PlayerInfoOnClick>();
            //if (playerInfoOnClick != null)
            //{
            //    Debug.Log("执行脚本上onclick方法");
            //    //执行脚本上onclick方法
            //    playerInfoOnClick.OnClick();
            //    return;
            //}

            // 判断是否有角色 
            //同样执行OnClick
        }


    }

    /// <summary>
    /// 获取所有创建的角色
    /// </summary>
    /// <returns></returns>
    public List<PlayerData> GetPlayerDatas()
    {
        return creatRoleUI.GetPlayerDatas();
    }

    /// <summary>
    /// 切换到选择面板
    /// </summary>
    public void ShowChooseRoleUI()
    {
        creatRoleUI.Hide();
        chooseRoleUI.Show();
    }

    /// <summary>
    /// 拿到角色创建工厂
    /// </summary>
    /// <returns></returns>
    public ICharacterFactory GetCharacterFatory()
    {
        return m_CharacterFactory;
    }

    /// <summary>
    /// 创人 选人时人物模型的显示 
    /// </summary>
    /// <param name="PlayType"></param>
    /// <param name="root"></param>
    /// <param name="v3"></param>
    public void CreatOrChooseRole(Role PlayType,Transform root,Vector3 v3)
    {
        if (roleManager.Get(PlayType))
        {
            roleManager.ChooseOrCreat(PlayType,root,v3);
        }
        else
        {
            if (m_CharacterFactory == null)
            {
                m_CharacterFactory = new CharacterFactory();
            }
            GameObject ga = m_CharacterFactory.CreatRole(PlayType, 1, root, v3);
           
            roleManager.Add(root,PlayType, ga);
            roleManager.ChooseOrCreat(PlayType, root, v3);

        }


    }

    /// <summary>
    /// 用来检测游戏是否结束
    /// </summary>
    /// <returns></returns>
    public bool ThisGameIsOVer()
    {
        return m_bGameOver;
    }

    /// <summary>
    /// 显示兵营信息
    /// </summary>
    ///// <param name="camp"></param>
    //public void ShowCampInfo(ICamp camp)
    //{
    //    //campInfoUI.ShowInfo(camp);
    //}

    ////获取选择的游戏角色信息
    public PlayerData GetPlayerData()
    {
       return chooseRoleUI.GetPlayerData();
    }
    /// <summary>
    /// 设置保存场景的管理类
    /// </summary>
    /// <param name="sceneStateController"></param>
    public void SetStateController(SceneStateController sceneStateController)
    {
        stateController = sceneStateController;
    }

    /// <summary>
    /// 获取场景管理类
    /// </summary>
    /// <returns></returns>
    public SceneStateController GetStateController()
    {
        return stateController;
    }
    /// <summary>
    /// 利用场景管理类切换场景状态
    /// </summary>
    /// <param name="sceneState"></param>
    /// <param name="name"></param>
    public void SetState(ISceneState sceneState,string name)
    {
        stateController.SetState(sceneState,name);
    }

    /// <summary>
    /// 切换到创建面板
    /// </summary>
    public void ShowCreatRoleUI()
    {
        creatRoleUI.Show();
        chooseRoleUI.Hide();
    }

    //创建主角命令
    public void CreatPlayerCommmand()
    {
        PlayerData playerData = GetPlayerData();
        //创建命令
        TrainSoldierCommand NewCommand = new TrainSoldierCommand(playerData.RoleType, playerData.lv, Vector3.zero);
        //添加到主角命令管理里
        commondSystem.Add(NewCommand);
    }

   
    /// <summary>
    /// 显示玩家属性面板
    /// </summary>
    public void ShowPlayerInfoUI()
    {
        playerInfoUI.Show();
    }

    /// <summary>
    /// 将玩家设置给玩家管理类里 控制移动
    /// </summary>
    /// <param name="game"></param>
    public void SetCharacterConGameObj(GameObject game)
    {
        characterControlSystem.SetGameObject(game);
    }


    public void AddEnemy(IEnemy theEnemy)
    {
        if (m_CharacterSystem != null)
            m_CharacterSystem.AddEnemy(theEnemy);
    }

    
    //public int GetEnemyCount()
    //{
    //    if (m_CharacterSystem != null)
    //        return m_CharacterSystem.GetEnemyCount();
    //    return 0;
    //}

}
