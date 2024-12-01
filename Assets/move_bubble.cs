using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_bubble : MonoBehaviour
{
    Transform m_Transform;
    private Vector3 direction;
    private bool goUp = true; 
    public float targetTime = 2.0f;
    public float speed = 2.0f;
    // public ParticleSystem burstParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();
        direction = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            if (goUp)
            {
                direction = Vector3.down;
                goUp = false;
            }
            else
            {
                direction = Vector3.up;
                goUp = true;
            }
            targetTime = 2.0f;
        }
        m_Transform.Translate(direction * Time.deltaTime * speed);
        // direction = Vector3.zero;
    }
}
