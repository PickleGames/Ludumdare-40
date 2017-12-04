using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPosition : MonoBehaviour {

    public float parentWidthPercent;
    public float parentHeightPercent;
    public int xMul;
    public int yMul;
    private RectTransform textRect;
    private RectTransform parentRect;

    void Start()
    {
        parentRect = gameObject.transform.parent.GetComponentInParent<RectTransform>();
        textRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = xMul * ((textRect.rect.width / 2) + parentRect.rect.width * parentWidthPercent / 100);
        float y = yMul * ((textRect.rect.height / 2) + (parentRect.rect.height * parentHeightPercent / 100));
        textRect.anchoredPosition = new Vector3(x, y, 0);
    }
}
