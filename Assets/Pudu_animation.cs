using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pudu_animation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("Walk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
