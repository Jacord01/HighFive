using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHeight : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (transform.position.y > 1) transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        else if(transform.position.y < 1) transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
