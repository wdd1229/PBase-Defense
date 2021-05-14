using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAssetFactory : MonoBehaviour
{
	// 產生Role
	public abstract GameObject LoadSoldier(string AssetName);

	// 產生Enemy
	public abstract GameObject LoadEnemy(string AssetName);

	// 產生Weapon
	public abstract GameObject LoadWeapon(string AssetName);

	// 產生特效
	public abstract GameObject LoadEffect(string AssetName);

	// 產生AudioClip
	public abstract AudioClip LoadAudioClip(string ClipName);

	// 產生Sprite
	public abstract Sprite LoadSprite(string SpriteName);
}
