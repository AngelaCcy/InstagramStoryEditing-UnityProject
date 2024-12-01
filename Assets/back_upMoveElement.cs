using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class back_upMoveElement : MonoBehaviour
{
    // Start is called before the first frame update
    Transform m_Transform;
    private Vector3 direction;
    private bool rotate;
    private bool grabbed = false;
    private bool isOnImage = false;
    // float m_XAxis, m_YAxis;
    
    void Start()
    {
        //Fetch the RectTransform from the GameObject
        m_Transform = GetComponent<Transform>();
        direction = new Vector3(-1f, 1f, 0);
        m_Transform.rotation = Quaternion.Euler(0, 231, 0);
        rotate = false;
        //Initiate the x and y positions
        // m_XAxis = 0.5f;
        // m_YAxis = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnImage == false)
        {
            m_Transform.Translate(direction * Time.deltaTime);
            // m_Transform.position += direction * Time.deltaTime;
            if (m_Transform.position.x >= 2.5f)
            {
                // direction = new Vector3(0f, -1f, 0);
                if (m_Transform.position.y <= 1.5f)
                {
                    // if (rotate == false)
                    // {
                    //     // m_Transform.Rotate(0,55,0);
                    //     m_Transform.rotation = Quaternion.Euler(0, 55, 0);
                    //     rotate = true;
                    // }
                    direction = new Vector3(1f, 1f, 0);
                }
                else
                {
                    direction = new Vector3(0f, -1f, 0);
                }
            }
            else if (m_Transform.position.x <= -2.5f)
            {
                if (m_Transform.position.y <= 1.5f)
                {
                    direction = new Vector3(-1f, 1f, 0);
                }
                else
                {
                    direction = new Vector3(0f, -1f, 0);
                }
            }
        }
        // if (m_Transform.position.y <= 1.5f)
        // {
        //     direction = new Vector3(1f, 1f, 0);
        // }
        // else
        // {
        //     direction = new Vector3(0f, -1f, 0);
        // }
        // }else if (m_Transform.position.x >= 5f)
        // {
        //     if (m_Transform.position.y <= -3f)
        //     {
        //         direction = new Vector3(-1f, 1f, 0);
        //     }
        //     else
        //     {
        //         direction = new Vector3(0f, -1f, 0);
        //     }
        // }
    }
    // public void WhenGrabbing()
    // {
    //     grabbed = true;
    // }

    public void UnGrabbing()
    {
        // if ()
        // {
        //     isOnImage == true
        // }
        // else
        // {
        //     isOnImage == false 
        // }
    }
}

