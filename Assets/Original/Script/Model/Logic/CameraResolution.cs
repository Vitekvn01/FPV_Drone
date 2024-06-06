using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    // Ўирина и высота, к которым вы хотите прив€зать камеру
    public int targetWidth = 1920;
    public int targetHeight = 1080;

    void Start()
    {
        // ќпредел€ем соотношение сторон экрана
        float targetRatio = (float)targetWidth / targetHeight;
        float currentRatio = (float)Screen.width / Screen.height;

        // ¬ычисл€ем масштаб
        float scaleHeight = currentRatio / targetRatio;

        Camera camera = GetComponent<Camera>();

        // ≈сли текущее соотношение сторон меньше целевого, удал€ем черные полосы по вертикали
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            // ≈сли текущее соотношение сторон больше целевого, удал€ем черные полосы по горизонтали
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}
