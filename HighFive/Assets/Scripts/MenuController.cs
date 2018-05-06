<<<<<<< HEAD
﻿using System.Collections;
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
=======
﻿using System.Collections;
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
>>>>>>> d0b1199e2769c1b2555cbc1caa3bb17a49ac1af0
