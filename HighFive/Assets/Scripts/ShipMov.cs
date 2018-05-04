using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMov : MonoBehaviour {

    RaycastHit hit;
    Vector3 oriPos;
    Quaternion oriRotation;
    // Use this for initialization
    void Start () {
        oriPos = this.transform.position;
        oriRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
   
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f / 2 * Mathf.Sin(Time.time * 2)
        //  , this.transform.position.z);

        if (transform.position.y > oriPos.y)
            this.transform.position = new Vector3(oriPos.x, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(0, 0, 3 * Time.deltaTime) ;
        else
            this.transform.Translate(0, 0, 0);

        if (Input.GetKey(KeyCode.A))
            this.transform.Rotate(0, -30 * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.D))
            this.transform.Rotate(0, 30 * Time.deltaTime,0);

    }

}

