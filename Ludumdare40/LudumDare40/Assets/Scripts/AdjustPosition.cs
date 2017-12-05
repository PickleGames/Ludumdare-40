using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPosition : MonoBehaviour {

    public float parentWidthPercent;
    public float parentHeightPercent;
    public int xMul;
    public int yMul;

    public float widthPercent;
    public float heightPercent;

    private RectTransform currentRect;
    private RectTransform parentRect;

    void Start()
    {
        parentRect = gameObject.transform.parent.GetComponentInParent<RectTransform>();
        currentRect = GetComponent<RectTransform>();
        Debug.Log("current size: " + currentRect.sizeDelta);
        Debug.Log("parent size: " + parentRect.rect.size);
    }

    // Update is called once per frame
    void Update()
    {

        float x = xMul * ((currentRect.rect.width / 2) + parentRect.rect.width * parentWidthPercent / 100);
        float y = yMul * ((currentRect.rect.height / 2) + (parentRect.rect.height * parentHeightPercent / 100));
        currentRect.anchoredPosition = new Vector3(x, y, 0);

        currentRect.sizeDelta = new Vector2(parentRect.rect.size.x * (widthPercent / 100), parentRect.rect.size.y * (heightPercent/ 100));
        
    }
}
