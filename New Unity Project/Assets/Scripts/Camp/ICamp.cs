using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 兵营 父级
/// </summary>
public abstract class ICamp  
{
    //训练角色的命令集合
    protected List<ITrainCommand> m_TrainCommands = new List<ITrainCommand>();
    

    protected GameObject m_GameObject = null;
    //兵营的名称
    protected string Name = "NUll";

    protected string IconnSpriteName = "";

    //兵营的类型
    protected ENUM_Soldier enSoldier = ENUM_Soldier.Null;

    //冷却剩余时间
    protected float m_CommandTim = 0;
    // 冷却時間 
    protected float m_TrainCoolDown = 0;

    //花费
    protected ITrainCost TrainCost = null;

    public string GetName()
    {
        return Name;
    }

    // 等級
    public virtual int GetLevel()
    {
        return 0;
    }


    protected PBaseDefenseGame m_PBDGame=null;
    public ICamp(GameObject game,float CoolDown,string name,string spriteName) 
    {
        m_GameObject = game;
        m_TrainCoolDown = CoolDown;

        m_CommandTim = m_TrainCoolDown;
        Name = name;
        IconnSpriteName = spriteName;
        TrainCost = new TrainCost();
    }

    public  string GetSpriteIcon()
    {
        return IconnSpriteName;
    } 

    //设置pbdg
    public void SetPBaseDefenseGame(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    //增加命令
    protected void AddCommand(ITrainCommand Command)
    {
        m_TrainCommands.Add(Command);
    }
    //删除命令
    public void RemoveCommand(ITrainCommand Command)
    {
        if (m_TrainCommands.Count == 0)
        {
            return;
        }
        
        //移除最后一个的命令
        m_TrainCommands.RemoveAt(m_TrainCommands.Count - 1);
    }

    //执行命令
    public void RunCommand()
    {
        //是否有命令
        if (m_TrainCommands.Count == 0)
        {
            return;
        }
       
        //冷却时间
        m_CommandTim -= Time.deltaTime;

        if (m_CommandTim > 0)
        {
            //时间不到
            return;
        }

        m_CommandTim = m_TrainCoolDown;

        //执行第一个命令
        m_TrainCommands[0].Execute();

        //执行之后把第一个移除
        m_TrainCommands.RemoveAt(0);

    }

    //训练需要的花费
    public abstract int GetTrainCost();

    //开始训练
    public abstract void Train();

    // 武器升级的消耗
    public virtual int GetWeaponLevelUpCost() { return 0; }

    // 武器升級
    public virtual void WeaponLevelUp() { }

}
