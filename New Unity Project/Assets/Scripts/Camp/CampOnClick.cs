using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 兵营被点击
/// </summary>
public class CampOnClick : MonoBehaviour
{
    public ICamp theCamp = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 点击
    /// </summary>
    public void OnClick()
    {
        //调用PBDG通知界面 显示兵营信息
        //PBaseDefenseGame.Instance.ShowCampInfo(theCamp);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
