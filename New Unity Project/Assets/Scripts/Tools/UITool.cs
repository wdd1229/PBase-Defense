﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// 找到UI上的物体
/// </summary>
public static class UITool
{
	private static GameObject m_CanvasObj = null; // 找到Canvas

	public static void ReleaseCanvas()
	{
		m_CanvasObj = null;
	}

	 //找UI
	public static GameObject FindUIGameObject(string UIName)
	{
		if(m_CanvasObj == null)
			m_CanvasObj = UnityTool.FindGameObject( "Canvas" );
		if(m_CanvasObj ==null)
			return null;
		return UnityTool.FindChildGameObject( m_CanvasObj, UIName);
	}
	
	// 取得UI
	public static T GetUIComponent<T>(GameObject Container,string UIName) where T : UnityEngine.Component
	{
		// 找出子物件 
		GameObject ChildGameObject = UnityTool.FindChildGameObject( Container, UIName);
		if( ChildGameObject == null)
			return null;
		
		T tempObj = ChildGameObject.GetComponent<T>();
		if( tempObj == null)
		{
			 		
			return null;
		}
		return tempObj;
	}
	
	public static Button GetButton(string BtnName)
	{
		// 取得Canvas
		GameObject UIRoot = GameObject.Find("Canvas");
		if(UIRoot==null)
		{
			Debug.LogWarning("沒有UI Canvas");
			return null;
		}
		
		// 找出對應的Button
		Transform[] allChildren = UIRoot.GetComponentsInChildren<Transform>();
		foreach(Transform child in allChildren)
		{
			if( child.name == BtnName ) 
			{
				Button tmpBtn = child.gameObject.GetComponent<Button>();
				if(tmpBtn == null)				
					Debug.LogWarning("类型不对");
				return tmpBtn;
			}	
		}

		Debug.LogWarning("UI Canvas中沒有Button["+BtnName+"]存在");
		return null;
	}

	// 取得UI
	public static T GetUIComponent<T>(string UIName) where T : UnityEngine.Component
	{
		// 取得Canvas
		GameObject UIRoot = GameObject.Find("Canvas");
		if(UIRoot==null)
		{
			Debug.LogWarning("沒有UI Canvas");
			return null;
		}
		return GetUIComponent<T>( UIRoot,UIName); 
	}
}
