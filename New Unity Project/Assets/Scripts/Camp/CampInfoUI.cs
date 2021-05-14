using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 兵营界面
/// </summary>
public class CampInfoUI : IUserInterface
{
    private ICamp m_Camp=null;//兵营
    

    //界面上的组件
    private Button m_LevelUpBtn = null;//兵营升级
    private Button m_WeaponLvUpBtn = null;//武器升级

    public CampInfoUI(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        //初始化
        Initialize();
    }

   

    Text CampName;
    Image CampIcon;
    Text CampLv;
    Button CampLvUpBtn;//兵营升级
    Text WeaponLevel;
    Button WeaponLevelBtn;//武器升级
    Button TrainSoldierBtn;//训练按钮
    Text TrainSoldier;
    public override void Initialize()
    {
        //找到父级 兵营界面
        m_RootUI = UITool.FindUIGameObject("CampInfoUI");

        //找到界面上 的各种物体或组件
        CampName = UITool.GetUIComponent<Text>(m_RootUI, "CampName");
        CampIcon = UITool.GetUIComponent<Image>(m_RootUI, "CampIcon");
        CampLv = UITool.GetUIComponent<Text>(m_RootUI, "CampLv");
        CampLvUpBtn = UITool.GetUIComponent<Button>(m_RootUI, "CampLvUpBtn");
        WeaponLevel = UITool.GetUIComponent<Text>(m_RootUI, "WeaponLevel");
        WeaponLevelBtn = UITool.GetUIComponent<Button>(m_RootUI, "WeaponLevelBtn");
        TrainSoldierBtn = UITool.GetUIComponent<Button>(m_RootUI, "TrainSoldierBtn");

        TrainSoldier = UITool.GetUIComponent<Text>(m_RootUI, "TrainSoldier");

        //给btn添加监听事件 升级 训练 取消训练
        TrainSoldierBtn.onClick.AddListener(() => TrainCommand());

        //升级
        CampLvUpBtn.onClick.AddListener(() => OnLevelUpBtnClick());

        WeaponLevelBtn.onClick.AddListener(() => OnWeaponLevelUpBtnClick());

        //因为是点击兵营时显示 所以先隐藏
        Hide();
    }

    void TrainCommand()
    {
        //训练命令
        Debug.Log("训练");
        Debug.Log(m_Camp);
        m_Camp.Train();
    }

    //武器升级
    public void OnWeaponLevelUpBtnClick()
    {
        Debug.Log("武器升级");
        //判断是否为最高等级

        //判断Ap是否足够
    }

    public void OnLevelUpBtnClick()
    {
        Debug.Log("兵营升级");
    }

    //隐藏
    public override void Hide()
    {
        base.Hide();
    }

    //展示兵营信息
    public void ShowInfo(ICamp camp)
    {
        //先显示出来
        Show();

        //兵营赋值
        m_Camp = camp;

        //名称
        CampName.text = m_Camp.GetName();

        //训练花费
        TrainSoldier.text = m_Camp.GetTrainCost().ToString();

        //训练中Ui显示
        ShowOnTrainInfo();

        //通过PBDG拿到资源Asset工厂  加载图片显示

        Debug.Log("Sprites/" + m_Camp.GetSpriteIcon());
        //这里暂时通过RES
        CampIcon.sprite= Resources.Load<Sprite>("Sprites/" + m_Camp.GetSpriteIcon());

        //通过ICamp 获取到等级 根据等级控制   等级 升级按钮和 武器等级 的显隐 

        //武器名字根据武器类型设置
    }

    //训练中Ui显示
    private void ShowOnTrainInfo()
    {
        if (m_Camp == null)
            return;

        //拿到训练的数量 也就是命令集合中的数量
        //显示

        //拿到ICamp中的训练时间 进行显示

        //拿到 存活的角色数量 显示

    }

    public override void Update()
    {
        ShowOnTrainInfo();
    }

   

    //训练
    public void OnTrainBtnClick()
    {
        //判断AP是否足够

        //使用Camp产生训练命令

        //兵营信息的跟新
        ShowInfo(m_Camp);

    }

}
