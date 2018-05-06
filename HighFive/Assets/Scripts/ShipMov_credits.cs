using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMov_credits : MonoBehaviour {

    public float health;
    public GameObject StandPoint1;
    public GameObject StandPoint2;
    public float speed = 10;


    // Use this for initialization

	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f / 10.5f * Mathf.Sin(Time.time * 2)
          , this.transform.position.z);

        if ((Input.GetKey(KeyCode.W)) || (Input.GetAxis("XBox_LeftStick_Vertical") > 0) || (Input.GetAxis("XBox_DPAD_Vertical") > 0))
            this.transform.Translate(0, -speed * Time.deltaTime,0 ) ;
        else
            this.transform.Translate(0, 0, 0);

        if ((Input.GetKey(KeyCode.A)) || (Input.GetAxis("XBox_LeftStick_Horizontal") > 0) || (Input.GetAxis("XBox_DPAD_Horizontal") > 0))
            this.transform.Rotate(0, 0, -30 * Time.deltaTime);
        else if ((Input.GetKey(KeyCode.D)) || (Input.GetAxis("XBox_LeftStick_Horizontal") < 0) || (Input.GetAxis("XBox_DPAD_Horizontal") < 0))
            this.transform.Rotate(0, 0, 30 * Time.deltaTime);

    }

    public  GameObject getSP1()
    {
        return StandPoint1;
    }

   public  GameObject getSP2()
    {
        return StandPoint2;
    }

    public void pierdeVida()
    {
        health -= 25;
    }

}

