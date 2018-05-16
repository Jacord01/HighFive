using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public Animator anim;
    public GameObject panel;

    private void Start()
    {
       
       
    }

    public void MoveCamera()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        panel.SetActive(false);
        anim.SetBool("playing", true);

    }
}
