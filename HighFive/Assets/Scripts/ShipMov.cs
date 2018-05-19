using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMov : MonoBehaviour {

    public float health;
    public GameObject StandPoint1;
    public GameObject StandPoint2;
    float speed = 0;
    public float maxSpeed = 10;
    float oriMaxSpeed = 10;
    public float velocity = 0.1f;
    bool StandPoint1Occupied_ = false;
    bool StandPoint2Occupied_ = false;

    // Update is called once per frame
    void Update () {

        if ((Input.GetKey(KeyCode.W)))
        {
            speed += velocity / 1.5f;
          
        }
        else
        {
            speed -= velocity / 1.5f;
        }

        if (speed > maxSpeed)
            speed = maxSpeed;
        else if (speed < 0)
            speed = 0;

        transform.Translate(0, -speed * Time.deltaTime, 0);


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, -speed * 2* Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.D) )
        {
             transform.Rotate(0, 0, speed * 2 * Time.deltaTime, Space.Self);
        }

    
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
        speed += 5;
        maxSpeed += 5;
        Invoke("ResetSpeed", 5f);
    }

    void ResetSpeed()
    {
        speed -= 5;
        maxSpeed = oriMaxSpeed;
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

    public void setSP(int i, bool s)
    {
        if (i == 1)
            StandPoint1Occupied_ = s;
        else if (i == 2)
            StandPoint2Occupied_ = s;
    }

    public bool getSP1State() { return StandPoint1Occupied_; }
    public bool getSP2State() { return StandPoint2Occupied_; }
}

