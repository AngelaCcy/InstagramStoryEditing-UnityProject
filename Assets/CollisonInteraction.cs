using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonInteraction : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        other.transform.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    // Update is called once per frame
    private void OnCollisionExit(Collision other)
    {
        other.transform.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    private void OnCollisionStay(Collision other)
    {
        Debug.Log("hitting something");
    }

    public void UnGrab()
    {
        Debug.Log("ungrab");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        
        // rb.freezeRotation = true;
    }
}
