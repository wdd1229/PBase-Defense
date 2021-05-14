using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 拖拽
/// </summary>
public class RoleDrag : MonoBehaviour,IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.Rotate(-Vector3.up * Input.GetAxis("Mouse X")*10);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
