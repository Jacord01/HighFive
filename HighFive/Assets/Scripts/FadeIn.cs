using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image image;

    public void OnEnable()
    {
        Debug.Log("FADE");
        Fade();
    }

    void Fade()
    {
        Color c = image.color;
        c.a += 0.01f;
        image.color = c;

        if (c.a >= 1) return;
        Invoke("Fade", 0.01f);
    }
}
