using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInteraction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _startPosition;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.position;
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }

    // Update is called once per frame
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        _rectTransform.position = _startPosition;
        _canvasGroup.blocksRaycasts = true;
    }
}
