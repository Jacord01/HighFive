using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMov : MonoBehaviour {

    public float health;
    public GameObject StandPoint1;
    public GameObject StandPoint2;
    public float speed = 10;


    // Use this for initialization

	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f / 10.5f * Mathf.Sin(Time.time * 2)
          , this.transform.position.z);

        if ((Input.GetKey(KeyCode.W)))
            this.transform.Translate(0, -speed * Time.deltaTime,0 ) ;
        else
            this.transform.Translate(0, 0, 0);

        if (Input.GetKey(KeyCode.A))
            this.transform.Rotate(0, 0, -30 * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
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
        health -= 26;
        GameManager.instance.checkPlayerHP(health);
    }

    public void AddVelocity()
    {
        speed *= 2;
        Invoke("ResetSpeed", 30f);
    }

    void ResetSpeed()
    {
        speed /= 2;
    }

    public void AddHealth()
    {
        health += 15;
        GameManager.instance.checkPlayerHP(health);
    }

    public void setHealth(int f)
    {
        health = f;
    }
}

