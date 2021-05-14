using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("人物信息");
        PBaseDefenseGame.Instance.ShowPlayerInfoUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
