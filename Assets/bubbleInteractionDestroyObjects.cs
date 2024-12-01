using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bubbleInteractionDestroyObjects : MonoBehaviour
{
    public ParticleSystem burstParticleSystem;
    public GameObject filterPrefab;
    public GameObject textPrefab;
    public GameObject photoCanvas;
    public GameObject camera;
    public GameObject bookmarkToActivate;
    // public Vector3 textPosition;
    // public string textToDisplay;
    
    public void When_Burst()
    {
        // Play burst animation
        burstParticleSystem.Play();
        Destroy(gameObject);
        
        // Create filter on the photo
        // If set the worldPositionStays to false, the created gameObject will use the position set in the prefab
        Instantiate(filterPrefab, photoCanvas.transform, false);
        
        //Display text to inform filter has been applied
        GameObject gameRoom = gameObject.transform.parent.parent.gameObject;
        GameObject text = Instantiate(textPrefab, gameRoom.transform, false);
        // text.transform.LookAt(camera.transform);
        // text.transform.localPosition = textPosition;
        // text.GetComponentInChildren<TMP_Text>().SetText(textToDisplay);
        
        // Activate bookmark
        bookmarkToActivate.SetActive(true);
        // if (gameObject.tag == "CloudBubble")
        // {
        //     // GameObject bookmark = GameObject.FindWithTag("CloudBookmark");
        //     GameObject bookmark = GameObject.FindGameObjectWithTag("CloudBookmark");
        //     bookmark.SetActive(true);
        // }
        // else if (gameObject.tag == "FlowerBubble")
        // {
        //     GameObject bookmark = GameObject.FindWithTag("FlowerBookmark");
        //     bookmark.SetActive(true);
        // }
    }
}
