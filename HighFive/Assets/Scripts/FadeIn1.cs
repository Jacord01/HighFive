using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn1 : MonoBehaviour {
    private RawImage img;
    private Color c;
    public AudioSource audio;

    private void Awake()
    {
        img = GetComponent<RawImage>();
        c = new Color();

    }
    private void Update()
    {
        c.r = 0;
        c.g = 0;
        c.b = 0;
        if (img.IsActive())
        {
            c.a += Time.deltaTime;
            img.color = c;
            audio.volume -= Time.deltaTime;
           
        }
       
        if (img.color.a >= 1f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
