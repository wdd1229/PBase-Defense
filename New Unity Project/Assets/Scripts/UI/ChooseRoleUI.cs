using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRoleUI : IUserInterface
{
    public ChooseRoleUI(PBaseDefenseGame PBDGame) : base(PBDGame)
    {


        Initialize();
    }
    GameObject root;
    public Transform selectRoot;
    public Transform RoleRoot;

    public Button CutBtn;
    bool IsRun = true;

    public Button StartGameBtn;
    List<PlayerData> playerDatas = new List<PlayerData>();
    private PlayerData playerData=null;
    public override void Initialize()
    {
        root = UITool.FindUIGameObject("ChooseRoleUI");
        selectRoot = UITool.GetUIComponent<Transform>(root, "SelectRoot");

        StartGameBtn = UITool.GetUIComponent<Button>(root, "StartGame");

        RoleRoot = UnityTool.FindGameObject("RolePos").transform;

        CutBtn = UITool.GetUIComponent<Button>(root, "CutBtn");

        CutBtn.onClick.AddListener(CutCreatRole);

        Debug.Log("隐藏");


        StartGameBtn.onClick.AddListener(StartGame);


        Hide();
    }

    private void CutCreatRole()
    {
        m_PBDGame.ShowCreatRoleUI();
    }

    private void StartGame()
    {
        if (playerData == null)
            return;

        //Debug.Log("主角为" + playerData.RoleType);
        SceneStateController stateController = PBaseDefenseGame.Instance.GetStateController();

        m_PBDGame.SetState(new BattleState(stateController), "BattleScene");
        //stateController.SetState(new BattleState(stateController), "BattleScene");

        //Debug.Log(stateController.m_State.StateName);
        
    }

    int index = -1;
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
                    //ind = index;

                    OnClick(index);
                }
            });
            if (index == 0)
            {
                ga.transform.GetComponent<Toggle>().isOn = true;
            }
        }
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }

    void OnClick(int index)
    {
        //if (index == -1)
        //{
        //    return;
        //}
        int a=(int)playerDatas[index].RoleType;
        Role roleType = (Role)(a + 1);
        //Debug.Log("ChooseChooseChooseChoose"+ playerDatas[index].RoleType);
        playerData = playerDatas[index];
        m_PBDGame.CreatOrChooseRole(roleType, RoleRoot, Vector3.zero);
    }

    private void CreatChooseRoleBtn(List<PlayerData> playerDatas)
    {
        this.playerDatas = playerDatas;

        Debug.Log(playerDatas.Count);
        for (int i = 0; i < selectRoot.childCount; i++)
        {
            GameObject ga = selectRoot.GetChild(i).gameObject;
            if (i < playerDatas.Count)
            {
                Debug.Log("???>>>>>");
                ga.transform.GetComponent<Toggle>().interactable = true;
                ga.transform.Find("Text").gameObject.SetActive(true);
                ga.transform.Find("Text").GetComponent<Text>().text = playerDatas[i].name;
            }
            else
            {
                ga.transform.GetComponent<Toggle>().interactable = false;
            }

        }
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

    }

    public override void Show()
    {
       
        DesRootChild();
        CreatChooseRoleBtn(m_PBDGame.GetPlayerDatas());
        root.gameObject.SetActive(true);
        OnClick(0);
        if (IsRun)
        {
            SelectMethod();
        }

    }

    public override void Hide()
    {
        root.gameObject.SetActive(false);
    }


}
