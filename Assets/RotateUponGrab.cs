using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUponGrab : MonoBehaviour
{
    public enum BUTTON_TYPE
    {
        NONE = 0,
        LEFT_BUTTON = 1,
        RIGHT_BUTTON = 2,
    }
    public GameObject objectToManipulate;
    private bool spinning = false;
    public BUTTON_TYPE btn_type = BUTTON_TYPE.NONE;
    // public string btnTag_l = "Rotate_left";
    // public string btnTag_r = "Rotate_right";
    // Transform m_Transform;
    // Start is called before the first frame update
    void Start()
    {
        // m_Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (btn_type)
        {
            case BUTTON_TYPE.NONE:
                break;
            case BUTTON_TYPE.LEFT_BUTTON:
                // objectToManipulate.transform.Rotate(Vector3.up);
                objectToManipulate.transform.Rotate(new Vector3(0, 0.45f, 0));
                break;
            case BUTTON_TYPE.RIGHT_BUTTON:
                // objectToManipulate.transform.Rotate(Vector3.down);
                objectToManipulate.transform.Rotate(new Vector3(0, -0.45f, 0));
                break;
        }

        // if (spinning)
        //     // if (other.CompareTag(btnTag_l))
        //     // {
        //     objectToManipulate.transform.Rotate(Vector3.up);
        //     // }
    }

    public void Left_btn_Grabbing()
    {
        // if (other.CompareTag(btnTag_l))
        // {
        // spinning = true;
        btn_type = BUTTON_TYPE.LEFT_BUTTON;
        // }
    }
    
    public void Right_btn_Grabbing()
    {
        // if (other.CompareTag(btnTag_l))
        // {
        // spinning = true;
        btn_type = BUTTON_TYPE.RIGHT_BUTTON;
        // }
    }

    public void UnGrabbing()
    {
        btn_type = BUTTON_TYPE.NONE;
    }
}
