using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 武器数值类
/// </summary>
public class WeaponAttr 
{
    public int Atk;//攻击力
    public float AtkRange;//攻击距离
    public string AttrName;//属性名称

    public WeaponAttr(int AtkValue,float Range,string AttrName)
    {
        this.Atk = AtkValue;
        this.AtkRange = Range;
        this.AttrName = AttrName;
    }
}
