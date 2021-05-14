using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : IUserInterface
{
    public PlayerData playerData=null;
     public PlayerInfoUI(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        playerData = m_PBDGame.GetPlayerData();
        Initialize();
    }

    public GameObject Root;
    public Button HeadBtn;
    public Transform InfoRoot;
    public Button CloseBtn;
    public Text PlayerName;
    public Text PlayerLevel;
    public Text PlayerType;
    public override void Initialize()
    {
        string[] arr = new string[] { "战士", "法师", "暗巫" };
        Root = UITool.FindUIGameObject("PlayerInfoUI");

        HeadBtn = UITool.GetUIComponent<Button>(Root, "HeadBtn");

        Image icon = HeadBtn.transform.GetComponent<Image>();
        //Debug.LogError()
        //icon.sprite = Resources.Load<Sprite>("UI/"+(int)playerData.RoleType);
        IAssetFactory assetFactory = PBDFactory.GetAssetFactory();
        icon.sprite= assetFactory.LoadSprite(((int)playerData.RoleType).ToString());

        PlayerName = UITool.GetUIComponent<Text>(Root, "PlayerName");
        PlayerName.text = playerData.name;

        GameObject PlayerLevelRoot = UITool.FindUIGameObject("PlayerLevelRoot");
        PlayerLevel = UITool.GetUIComponent<Text>(PlayerLevelRoot, "PlayerLevel");
        PlayerLevel.text = playerData.lv.ToString();


        GameObject PlayerTypeRoot = UITool.FindUIGameObject("PlayerTypeRoot");
        PlayerType = UITool.GetUIComponent<Text>(PlayerTypeRoot, "PlayerType");
        PlayerType.text = arr[(int)playerData.RoleType];


        //Debug.LogError("UI/" + (int)playerData.RoleType);


        InfoRoot = UITool.GetUIComponent<Transform>(Root, "PlayerInfo");

        CloseBtn = UITool.GetUIComponent<Button>(InfoRoot.gameObject, "CloseBtn");


        InfoRoot.gameObject.SetActive(false);

        CloseBtn.onClick.AddListener(Hide);


        HeadBtn.onClick.AddListener(Show);
    }

    

    public override void Release()
    {
        base.Release();
    }

    public override void Show()
    {
        InfoRoot.gameObject.SetActive(true);
        HeadBtn.gameObject.SetActive(false);
    }

    public override void Hide()
    {
        InfoRoot.gameObject.SetActive(false);
        HeadBtn.gameObject.SetActive(true);
    }
}
