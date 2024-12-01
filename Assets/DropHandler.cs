using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    public void OnDrop(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
