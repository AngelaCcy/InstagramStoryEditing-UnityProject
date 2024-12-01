using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo_collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        //comment
        // audioSource.PlayOneShot(onthephoto_audioClip, 0.7f);
        Debug.Log(other.gameObject.name);
        Debug.Log("Collision");
    }
}
