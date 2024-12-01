using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backup_RotateUponGrab : MonoBehaviour
{
    public GameObject objectToManipulate;
    private bool spinning = false;
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
        if (spinning)
            // if (other.CompareTag(btnTag_l))
            // {
            objectToManipulate.transform.Rotate(Vector3.up);
            // }
    }
    
    

    public void WhenGrabbing()
    {
        // if (other.CompareTag(btnTag_l))
        // {
        spinning = true;
        // }
    }

    public void UnGrabbing()
    {
        spinning = false;
    }
}
