using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 建立Enemy的參數
public class EnemyBuildParam : ICharacterBuildParam
{
    public Vector3 AttackPosition = Vector3.zero; // 要前往的 
    public EnemyBuildParam()
    {
    }
}
public class EnemyBuilder : ICharacterBuilder
{
    private EnemyBuildParam m_BuildParam = null;
    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParam = theParam as EnemyBuildParam;
    }

    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
        GameObject EnemyGameObject = AssetFactory.LoadEnemy(m_BuildParam.NewCharacter.GetAssetName());
        EnemyGameObject.transform.position = m_BuildParam.SpawnPosition;
        EnemyGameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        EnemyGameObject.gameObject.name = string.Format("Enemy[{0}]", GameObjectID);
        m_BuildParam.NewCharacter.SetGameObject(EnemyGameObject);
    }

    public override void AddOnClickScript()
    {
        
    }

    public override void AddWeapon()
    {
         
    }

    public override void SetCharacterAttr()
    {
        // 取得Enemy的數值
        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
        int AttrID = m_BuildParam.NewCharacter.GetAttrID();
        EnemyAttr theEnemyAttr = theAttrFactory.GetEnemyAttr(AttrID);
        //算法
        //theEnemyAttr.SetAttStrategy(new EnemyAttrStrategy());

        // 給角色
        //m_BuildParam.NewCharacter.SetCharacterAttr(theEnemyAttr);
    }

    public override void AddAI()
    {
        //EnemyAI theAI = new EnemyAI(m_BuildParam.NewCharacter, m_BuildParam.AttackPosition);
        //m_BuildParam.NewCharacter.SetAI(theAI);
    }

    public override void AddCharacterSystem(PBaseDefenseGame PBDGame)
    {
        PBDGame.AddEnemy(m_BuildParam.NewCharacter as IEnemy);
    }
}
