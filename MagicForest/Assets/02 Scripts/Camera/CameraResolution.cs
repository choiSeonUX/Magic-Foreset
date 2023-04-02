using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleHeigth = ((float)Screen.width / Screen.height) / ((float)16 /9);
        float scaleWidth = 1f / scaleHeigth;

        if (scaleHeigth < 1)
        {
            rect.height = scaleHeigth;
            rect.y = (1f - scaleHeigth) / 2f;
        }
        else
        {
            rect.width = scaleWidth;
            rect.x = (1f - scaleWidth) / 2f;
        }
        camera.rect = rect; 
    }
}
