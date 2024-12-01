using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddImage : MonoBehaviour
{
    public GameObject canvas;

    public Image addImage;

    // Start is called before the first frame update
    void Start()
    {
        GameObject imgObject = new GameObject("testAAA");

        RectTransform trans = imgObject.AddComponent<RectTransform>();
        trans.transform.SetParent(canvas.transform); // setting parent
        trans.localScale = Vector3.one;
        trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        trans.sizeDelta = new Vector2(15, 20); // custom size

        Image image = imgObject.AddComponent<Image>();
        image.sprite = addImage.sprite;

    }
}
