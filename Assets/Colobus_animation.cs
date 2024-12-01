using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colobus_animation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("Sit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
