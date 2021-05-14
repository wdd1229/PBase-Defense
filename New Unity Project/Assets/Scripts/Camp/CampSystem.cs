using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 兵营系统
/// </summary>
public class CampSystem : IGameSystem
{
    //我方兵营
    private Dictionary<ENUM_Soldier, ICamp> SoldierCamps = new Dictionary<ENUM_Soldier, ICamp>();
    //地方兵营
    private Dictionary<ENUM_Enemy, ICamp> CaptiveCamps = new Dictionary<ENUM_Enemy, ICamp>();

    public CampSystem(PBaseDefenseGame PBDGame):base(PBDGame)
    {
        //初始
        Initialize();
    }

    //初始化
    public override void Initialize()
    {
        //base.Initialize();
        //创建兵营

        SoldierCamps.Add(ENUM_Soldier.Rookie, SoldierCampFactory(ENUM_Soldier.Rookie));


        //注册事件 观察者 角色死亡时Ui  

        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.SoldierKilled, new SoldierKilledObserverUI());
    }

    /// <summary>
    /// 产生兵营并和界面物体绑定
    /// </summary>
    /// <param name="soldierType"></param>
    private SoldierCamp SoldierCampFactory(ENUM_Soldier soldierType)
    {
        //拼接成场景中的兵营名 用来查找绑定物体
        string GameObjectName = "SoldierCamp_";
        //兵营名称
        string CampName = "";

        //图片
        string IConSprite = "";

        switch (soldierType)
        {
            //根据类型 确定兵营名称 和场景中物体名称
            case ENUM_Soldier.Rookie:
                GameObjectName += "Rookie";
                CampName += "菜鸟";
                IConSprite = "RookieCamp";
                break;
            case ENUM_Soldier.Sergeant:
                GameObjectName += "Sergeant";
                CampName += "新人";
                IConSprite = "SergeantCamp";
                break;
            case ENUM_Soldier.Captain:
                GameObjectName += "Captain";
                CampName += "老兵";
                IConSprite = "CaptainCamp";
                break;
               

            default:
                break;
        }

        //查找到场景中物体 利用工具
        GameObject theGame = UnityTool.FindGameObject(GameObjectName);

        //找到集合点的Pos TrainPoint 

        //产生兵营 
        SoldierCamp SoldCamp = new SoldierCamp(theGame, soldierType, CampName, IConSprite, 2, Vector3.zero);

        SoldCamp.SetPBaseDefenseGame(m_PBDGame) ;

        //给物体添加一个点击的脚本
        theGame.AddComponent<CampOnClick>().theCamp= SoldCamp;

        //兵营物体可以先隐藏

        return SoldCamp;

    }

    public override void Update()
    {
        Debug.Log("CampUpdate");
        foreach (var item in SoldierCamps.Values)
        {
            Debug.Log("CampUpdate里面");

            //执行 命令
            item.RunCommand();
        }
    }

}
