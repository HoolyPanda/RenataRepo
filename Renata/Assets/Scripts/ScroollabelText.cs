using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroollabelText : MonoBehaviour
{
    
    // Start is called before the first frame update
    public RectTransform textRect;
    public RectTransform contentRect;

    void Start()
    {
        // var b = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var size = contentRect.sizeDelta;
        size.y = textRect.sizeDelta.y;
        contentRect.sizeDelta = size;
    }
}
