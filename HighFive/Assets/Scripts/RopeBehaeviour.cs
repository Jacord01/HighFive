using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehaeviour : MonoBehaviour {

    public GameObject canvas;
	public void animFinished()
    {
        canvas.SetActive(true);
    }
}
