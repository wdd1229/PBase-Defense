using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// （创人选人）人物管理系统
/// </summary>
public class RoleManager : IGameSystem
{
    public RoleManager(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Cache = new Dictionary<Role, GameObject>();
        Initialize();
    }

    public Dictionary<Role, GameObject> Cache = null;
    public override void Initialize()
    {
         
    }

    public void Add(Transform root,Role RoleType,GameObject ga)
    {
        ga.transform.SetParent(root,false);

        if (Cache.ContainsKey(RoleType))
        {
            return;
        }
        else
        {
            
           
            Cache.Add(RoleType, ga);
            

        }
    }

    public GameObject player;
    //public void BattleCreat(Role RoleType, Transform root, Vector3 v3)
    //{
        
    //        GameObject ga = m_PBDGame.GetCharacterFatory().CreatRole(RoleType+1, 1, root, v3);
    //         player = GameObject.Instantiate(ga);
    //         player.transform.position = v3;
             
    //}

    public void ChooseOrCreat(Role RoleType,Transform root,Vector3 v3)
    {
        if (Cache.ContainsKey(RoleType))
        {
            if (root != null)
            {
                if (root.childCount > 0)
                {
                    for (int i = 0; i < root.childCount; i++)
                    {
                        //GameObject.Destroy(root.GetChild(i).gameObject);
                        root.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
            GameObject ga=Cache[RoleType];
            
            ga.SetActive(true);
            ga.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            //添加拖拽脚本
            ga.AddComponent<RoleDrag>();
        }
        
    }

    public bool Get(Role RoleType)
    {
        if (Cache.ContainsKey(RoleType))
        {
            return true;
        }

        return false;
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        Debug.Log("控制人物");

        //if (player != null)
        //{
        //    float h = Input.GetAxis("Horizontal");
        //    float v = Input.GetAxis("Vertical");
        //    if (h != 0 || v != 0)
        //    {
        //        player.transform.LookAt(player.transform.position+new Vector3(h,0,v));

        //        player.transform.Translate(Vector3.forward * 10*Time.deltaTime);
        //    }
        //}

      

    }
}
