using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToChangeColor : MonoBehaviour
{
    Transform m_Transform;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    public void WhenSelected()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        // Debug.Log("Selected");
        // m_Transform.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
