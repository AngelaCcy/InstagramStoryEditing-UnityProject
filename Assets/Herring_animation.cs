using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herring_animation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("Idle_B");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
