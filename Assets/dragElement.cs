using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICustomDrag
{
    void OnCurrentDrag();
}

// public class dragElement : MonoBehaviour, IDragHandler
// {
//     [SerializeField] GameObject objectToDrag;
//     private ICustomDrag onDrag;
//     // Start is called before the first frame update
//     void Start()
//     {
//         onDrag = objectToDrag.GetComponent<ICustomDrag>();
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
// }
