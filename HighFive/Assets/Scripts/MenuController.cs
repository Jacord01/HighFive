using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public Animator anim;
    public GameObject canvas;
    public GameObject flag;
    public GameObject rope;

    public void MoveCamera()
    {
        canvas.SetActive(false);
        flag.SetActive(false);
        rope.SetActive(false);
        anim.SetBool("playing", true);

    }
}
