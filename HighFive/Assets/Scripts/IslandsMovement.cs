using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandsMovement : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f / 10.5f * Mathf.Sin(Time.time * 2)
          , this.transform.position.z);
    }
}
