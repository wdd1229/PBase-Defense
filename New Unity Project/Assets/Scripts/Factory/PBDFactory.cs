using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管理工程
/// </summary>
public static class PBDFactory  
{
    public static ICharacterFactory CharacterFactory = null;//角色工厂

    private static IAssetFactory m_AssetFactory = null;

    private static IAttrFactory m_AttrFactory = null;

    public static IAssetFactory GetAssetFactory()
    {
        if (m_AssetFactory == null)
        {
            if (m_AssetFactory == null)
            {
                m_AssetFactory = new ResourceAssetProxyFactory();
            }
        }
        return m_AssetFactory;
    }

    /// <summary>
    /// 拿到创建角色的工厂
    /// </summary>
    /// <returns></returns>
    public static ICharacterFactory GetCharacterFactory()
    {
        if (CharacterFactory == null)
        {
            CharacterFactory = new CharacterFactory();

        }
        return CharacterFactory;
    }

    public static IAttrFactory GetAttrFactory()
    {
        if (m_AttrFactory == null)
            m_AttrFactory = new AttrFactory();

        return m_AttrFactory;
    }
}
