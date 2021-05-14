using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData
{
   public PlayerData(int l,Role ty, string na)
    {
        lv = l;
        RoleType = ty;
        name = na;
    }
    public int lv;
    public Role RoleType;
    public string name;
}
public enum Role
{
    Warrior,//战士
    Rule,//法师
    Sorcerer,//暗巫
    Null
}
public class CreatRoleUI : IUserInterface
{
    GameObject root;
    public Transform selectRoot;
    public InputField input;
    public Button RondomNameBtn;
    public Button CreatBtn;

    public Button CutBtn;

    public Transform RoleRoot;

    int ind=0;
    public CreatRoleUI(PBaseDefenseGame PBDGame):base(PBDGame)
    {
        playerDatas = new List<PlayerData>();
        Initialize();
    }

    List<PlayerData> playerDatas = null;

    string[] arr = new string[] { "战士", "法师", "暗巫" };
    //查找物体并绑定
    public override void Initialize()
    {
        root= UITool.FindUIGameObject("CreatRoleUI");
        selectRoot = UITool.GetUIComponent<Transform>(root, "SelectRoot");
        input = UITool.GetUIComponent<InputField>(root, "InputField");
        RondomNameBtn = UITool.GetUIComponent<Button>(root, "RondomNameBtn");
        CreatBtn = UITool.GetUIComponent<Button>(root, "CreatBtn");
        RoleRoot = UnityTool.FindGameObject("RolePos").transform;

        CutBtn = UITool.GetUIComponent<Button>(root, "CutBtn");

        CutBtn.onClick.AddListener(CutCreatRole);

        RondomNameBtn.onClick.AddListener(RondomName);

        CreatBtn.onClick.AddListener(CreatRole);
  
        SelectMethod();

        
    }

    private void CutCreatRole()
    {
        if (playerDatas.Count == 0)
            return;
        m_PBDGame.ShowChooseRoleUI();
    }

    void CreatRole()
    {
        Debug.Log("创建人物");
        if (input.text == "")
        {
            return;
        }
        PlayerData playerData = new PlayerData(1, (Role)ind, input.text);
        playerDatas.Add(playerData);

        m_PBDGame.ShowChooseRoleUI();
    }

    private void DesRootChild()
    {
        if (RoleRoot.childCount > 0)
        {
            for (int i = 0; i < RoleRoot.childCount; i++)
            {
                RoleRoot.GetChild(i).gameObject.SetActive(false);
            }
        }
        OnClick(0);
    }

    public List<PlayerData> GetPlayerDatas()
    {
        return playerDatas;
    }

    void SelectMethod()
    {
        for (int i = 0; i < selectRoot.childCount; i++)
        {
            GameObject ga = selectRoot.GetChild(i).gameObject;
             int index = i;
            ga.transform.GetComponent<Toggle>().onValueChanged.AddListener((falg) =>
            {
                if (falg)
                {
                    ind = index;
                    OnClick(index);
                }
            });
            if (index == 0)
            {
                ga.transform.GetComponent<Toggle>().isOn = true;
            }
        }
    }

    public void OnClick(int index)
    {
        //Debug.Log("/*选择" + (Role)index);*/

        m_PBDGame.CreatOrChooseRole((Role)(index+1), RoleRoot, Vector3.zero);
        RondomName();
    }

    public void RondomName()
    {
        string name = arr[ind]+ UnityEngine.Random.Range(1,6);
        input.text = name;
    }

    public override void Release()
    {
        
    }

    public override void Show()
    {
        root.SetActive(true);
        DesRootChild();
        selectRoot.GetChild(0).transform.GetComponent<Toggle>().isOn = true;
    }

    public override void Hide()
    {
        root.SetActive(false);
    }
}
