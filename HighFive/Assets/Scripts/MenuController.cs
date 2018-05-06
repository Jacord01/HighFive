using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public Animator anim;
    public GameObject canvas;

    private void Start()
    {
       
       
    }

    public void MoveCamera()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        canvas.SetActive(false);
        anim.SetBool("playing", true);

    }
}
