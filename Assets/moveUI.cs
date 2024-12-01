using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class moveUI : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform m_RectTransform;
    private Vector2 direction;
    // float m_XAxis, m_YAxis;
    
    void Start()
    {
        //Fetch the RectTransform from the GameObject
        m_RectTransform = GetComponent<RectTransform>();
        direction = new Vector2(-1f, 1f);
        //Initiate the x and y positions
        // m_XAxis = 0.5f;
        // m_YAxis = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        m_RectTransform.anchoredPosition += direction * Time.deltaTime;
        if (m_RectTransform.anchoredPosition.x <= -5f)
        {
            if (m_RectTransform.anchoredPosition.y <= -3f)
            {

                direction = new Vector2(1f, 1f);
            }
            else
            {
                direction = new Vector2(0f, -1f);
            }
        }else if (m_RectTransform.anchoredPosition.x >= 5f)
        {
            if (m_RectTransform.anchoredPosition.y <= -3f)
            {
                direction = new Vector2(-1f, 1f);
            }
            else
            {
                direction = new Vector2(0f, -1f);
            }
        }
    }
}
