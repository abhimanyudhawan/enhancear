using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class MaxContentSize : MonoBehaviour
{
    public int maximumWidth = 100;

    private Rect parentRect;

    void Update()
    {
        RectTransform tr = transform.parent as RectTransform;
        if (tr == null) return; // No parent GUI element

        if (parentRect != tr.rect)
        {
            parentRect = tr.rect;
            if (parentRect.width > maximumWidth)
            {
                LayoutElement thisElement = GetComponent<LayoutElement>();
                thisElement.preferredWidth = maximumWidth;
            }
        }
    }
}