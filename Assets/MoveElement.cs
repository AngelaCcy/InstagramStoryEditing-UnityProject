using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveElement : MonoBehaviour
{
    public enum ELEMENT_STATE
    {
        IN_THE_ROOM = 0,
        ON_THE_WAY = 1,
        ON_THE_PHOTO =2
    }
    public enum MOVEMENT_STATE
    {
        FORWARD = 0,
        STAY = 1,
        // EAT = 2,
        BACKWARD = 3,
    }
    public ELEMENT_STATE elem_state = ELEMENT_STATE.IN_THE_ROOM;
    public MOVEMENT_STATE mov_state = MOVEMENT_STATE.FORWARD;
    Transform m_Transform;
    private Vector3 direction;
    private Vector3 _startPosition;
    private Rigidbody rb;
    public string uiImageTag = "Photo";
    private AudioSource audioSource;
    // public float leftTop, rightTop, leftBottom, rightBottom;
    public float rotateY;
    // public MOVEMENT_STATE mov_state;
    // public string movement;
    public AudioClip ontheway_audioClip;
    public AudioClip onthephoto_audioClip;
    public AudioClip putonthephoto_audioClip;
    private bool backwarded = false;
    private bool left_right_returned = false;
    private bool grabbed = false;
    // private float ENDTIME = 4.0f;
    private float targetTime = 4.0f;
    private Animator animator;
    public GameObject canvas;
    public GameObject prefab;
    public float object_facing_y;
    public float object_facing_x;
    public float object_scale;
    
    
    void Start()
    {
        //Fetch the RectTransform from the GameObject
        m_Transform = GetComponent<Transform>();
        // switch (m_Transform.tag)
        // {
        //     case "Move_around":
        //         direction = new Vector3(-1f, 1f, 0);
        //         break;
        //     case "Move_forward_backward":
        //         direction = new Vector3(0, 0, 1f);
        //         break;
        // }
        direction = new Vector3(-1.5f, 1f, 0);
        m_Transform.rotation = Quaternion.Euler(0, rotateY, 0);
        _startPosition = m_Transform.localPosition;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // m_Transform.Translate(direction * Time.deltaTime);
        switch (elem_state)
        {
            case ELEMENT_STATE.IN_THE_ROOM:
            {
                // moveElement(8f, 1.5f, 1.3f, 1.3f);
                
                // if (m_Transform.CompareTag("Move_around"))
                // {
                //     MoveAround(leftTop, rightTop, leftBottom, rightBottom);
                // }

                switch (m_Transform.tag)
                {
                    case "Move_around":
                        // MoveAround(leftTop, rightTop, leftBottom, rightBottom);
                        MoveAround(8f, 1.5f, 4f, 4f);
                        break;
                    case "Move_forward_backward":
                        MoveForBack(8.8f, 3.6f);
                        break;
                    case "Move_left_right":
                        MoveLeftRight(-9f, -2f);
                        break;
                }

                if (m_Transform.tag != "Stay")
                {
                    m_Transform.Translate(direction * Time.deltaTime);
                }
                
                // switch (mov_state)
                // {
                //     case MOVEMENT_STATE.AROUND:
                //         MoveAround(leftTop, rightTop, leftBottom, rightBottom);
                //         break;
                //     case MOVEMENT_STATE.BACK_FORWARD:
                //         MoveForBack(4f, -3.5f);
                //         break;
                // }
                // MoveAround(leftTop, rightTop, leftBottom, rightBottom);
                break;
            }
            case ELEMENT_STATE.ON_THE_WAY:
            {
                // m_Transform.position = _startPosition;
                m_Transform.localPosition = _startPosition;
                direction = new Vector3(-1.5f, 1f, 0);
                m_Transform.localRotation = Quaternion.Euler(0, 231, 0);
                elem_state = ELEMENT_STATE.IN_THE_ROOM;
                break;
            }
            case ELEMENT_STATE.ON_THE_PHOTO:
            {
                break;
            }
        }
    }

    public void MoveAround(float left_top, float right_top, float left_bottom, float right_bottom)
    {
        // m_Transform.Translate(direction * Time.deltaTime);
        if (m_Transform.localPosition.x >= left_top)
        {
            if (m_Transform.localPosition.y <= left_bottom)
            {
                direction = new Vector3(2f, 1.1f, 0);
            }
            else
            {
                direction = new Vector3(0, -1f, 0);
            }
        }
        else if (m_Transform.localPosition.x <= right_top)
        {
            if (m_Transform.localPosition.y <= right_bottom)
            {
                direction = new Vector3(-1.7f, 1f, 0);
            }
            else
            {
                direction = new Vector3(0f, -1f, 0);
            }
        }
    }

    public void MoveForBack(float start, float end)
    {
        switch (mov_state)
        {
            case MOVEMENT_STATE.FORWARD:
                if (m_Transform.localPosition.x <= end)
                {
                    mov_state = MOVEMENT_STATE.STAY;
                }
                direction = Vector3.right;
                break;
            case MOVEMENT_STATE.STAY:
                animator.Play("Sit");
                targetTime -= Time.deltaTime;
                if (targetTime <= 0.0f)
                {
                    mov_state = MOVEMENT_STATE.BACKWARD;
                    targetTime = 4.0f;
                }
                direction = Vector3.zero;
                break;
            // case MOVEMENT_STATE.EAT:
            //     animator.Play("Eat");
            //     targetTime -= Time.deltaTime;
            //     if (targetTime <= 0.0f)
            //     {
            //         mov_state = MOVEMENT_STATE.BACKWARD;
            //     }
            //     direction = Vector3.zero;
            //     break;
            case MOVEMENT_STATE.BACKWARD:
                animator.Play("Walk");
                if(m_Transform.localPosition.x >= start)
                {
                    mov_state = MOVEMENT_STATE.FORWARD;
                }
                direction = Vector3.left;
                break;
        }
        
        
        // if (m_Transform.localPosition.x <= end)
        // {
        //     backwarded = true;
        // }else if(m_Transform.localPosition.x >= start)
        // {
        //     backwarded = false;
        // }
        //
        // if (backwarded)
        // {
        //     direction = Vector3.left;
        // }
        // else
        // {
        //     direction = Vector3.right;
        // }
    }
    
    public void MoveLeftRight(float start, float end)
    {
        if (m_Transform.localPosition.z >= end)
        {
            left_right_returned = true;
        }else if(m_Transform.localPosition.z <= start)
        {
            left_right_returned = false;
        }

        if (left_right_returned)
        {
            direction = Vector3.forward;
        }
        else
        {
            direction = Vector3.back;
        }
    }
    
    public void WhenGrabbing()
    {
        grabbed = true;
        audioSource.PlayOneShot(putonthephoto_audioClip, 0.7f);
    }

    public void UnGrabbing()
    {
        // if (m_Transform.position != _startPosition && elem_state != ELEMENT_STATE.ON_THE_PHOTO)
        grabbed = false;
        if (m_Transform.localPosition != _startPosition && elem_state != ELEMENT_STATE.ON_THE_PHOTO)
        {
            elem_state = ELEMENT_STATE.ON_THE_WAY;
            audioSource.PlayOneShot(ontheway_audioClip, 0.7f);
        }
        else if (elem_state == ELEMENT_STATE.ON_THE_PHOTO)
        {
            if (gameObject.layer == 7)
            {
                Vector3 _AddImagePosition = m_Transform.position;
                Image addImage = GetComponentInChildren<Image>();
                RectTransform addImageRect = addImage.GetComponent<RectTransform>();
                GameObject imgObject = new GameObject("imageOnPhoto");
                RectTransform trans = imgObject.AddComponent<RectTransform>();
                trans.rotation = Quaternion.Euler(0, -115, 0);
                trans.transform.SetParent(canvas.transform); // setting parent
                trans.localScale = Vector3.one;
                // trans.anchoredPosition = new Vector2(_AddImagePosition.x, _AddImagePosition.y); // setting position, will be on center
                trans.position = _AddImagePosition;
                trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, 0);
                trans.sizeDelta = new Vector2(addImageRect.rect.width, addImageRect.rect.height); // custom size
                Image image = imgObject.AddComponent<Image>();
                image.sprite = addImage.sprite;

                elem_state = ELEMENT_STATE.ON_THE_WAY;
            }
            else
            {
                Vector3 _AddImagePosition = m_Transform.position;
                // Image addImage = GetComponentInChildren<Image>();
                // RectTransform addImageRect = addImage.GetComponent<RectTransform>();
                // GameObject imgObject = new GameObject("imageOnPhoto");
                // RectTransform trans = imgObject.AddComponent<RectTransform>();
                // trans.rotation = Quaternion.Euler(0, -115, 0);
                // trans.transform.SetParent(canvas.transform); // setting parent
                // trans.localScale = Vector3.one;
                // trans.position = _AddImagePosition;
                // trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, 0);
                // trans.sizeDelta = new Vector2(addImageRect.rect.width, addImageRect.rect.height); // custom size
                
                GameObject new3dObject = Instantiate(prefab, _AddImagePosition, Quaternion.Euler(object_facing_x, object_facing_y, 0), canvas.transform);
                new3dObject.transform.localScale = new Vector3(object_scale, object_scale, object_scale);
                new3dObject.transform.localPosition = new Vector3(new3dObject.transform.localPosition.x, new3dObject.transform.localPosition.y, -0.3f);

                elem_state = ELEMENT_STATE.ON_THE_WAY;
            }
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        // audioSource.PlayOneShot(onthephoto_audioClip, 0.7f);
        if (other.collider.CompareTag(uiImageTag) & grabbed)
        {
            // if (elem_state != ELEMENT_STATE.ON_THE_PHOTO)
            // {
            //     audioSource.PlayOneShot(onthephoto_audioClip, 0.7f);
            // }
            elem_state = ELEMENT_STATE.ON_THE_PHOTO;
            audioSource.PlayOneShot(onthephoto_audioClip, 0.7f);
        }
    }

    // private void OnCollisionStay(Collision other)
    // {
    //     if (grabbed)
    //     {
    //         audioSource.PlayDelayed(5000f);
    //         audioSource.PlayOneShot(onthephoto_audioClip, 0.2f);
    //         audioSource.PlayDelayed(5000f);
    //     }
    // }
    
    private void OnCollisionExit(Collision other)
    {
        audioSource.PlayOneShot(putonthephoto_audioClip, 0.7f);
        // elem_state = ELEMENT_STATE.ON_THE_WAY;
        // if (other.collider.CompareTag(uiImageTag) == false)
        // {
        //     isOnImage = false;
        // }
        // isOnImage = false;
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     // Check if the object entering the trigger is the UI Image
    //     if (other.CompareTag(uiImageTag))
    //     {
    //         isOnImage = true;
    //         Debug.Log("Butterfly is over UI Image");
    //     }
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     // Reset the flag when the butterfly exits the UI Image area
    //     if (other.CompareTag(uiImageTag))
    //     {
    //         isOnImage = false;
    //         Debug.Log("Butterfly is no longer over UI Image");
    //     }
    // }
}

