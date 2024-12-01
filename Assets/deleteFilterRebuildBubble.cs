using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteFilterRebuildBubble : MonoBehaviour
{
    public GameObject bubblePrefab;
    public string filterTag;
    
    public void WhenBtnClick()
    {
        // Deactivates bookMark Canvas
        GameObject bookmarkCanvas = gameObject.transform.parent.parent.gameObject;
        // bookmarkCanvas.SetActive(false);
        Destroy(bookmarkCanvas);
        
        // Rebuild bubble
        GameObject gameRoom = GameObject.FindWithTag("GameRoom");
        Instantiate(bubblePrefab, gameRoom.transform, false);
        
        // Destroy filter
        GameObject filter = GameObject.FindWithTag(filterTag);
        Destroy(filter);
    }
}
