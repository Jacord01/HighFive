using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFadeIn : MonoBehaviour {

    public Animator anim;
	public void blackFadeIn()
    {
        anim.SetBool("FADEBOOL", true);
    }
}
