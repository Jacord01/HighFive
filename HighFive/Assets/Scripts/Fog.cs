<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {

    private float shipHealth;
    private float timeInFog;
    public float reductionFactor;

    [HideInInspector]
    public bool outOfFog;
    

    private void Update()
    {
        if (outOfFog)
        {
            timeInFog += Time.deltaTime;
            reduceHP();
        }
      //  Debug.Log(health);

    }
    private void Start()
    {
        timeInFog = 0;
        shipHealth = gameObject.GetComponent<ShipMov>().health;
        outOfFog = false;
    }
    private void OnTriggerExit(Collider other)
    {
        outOfFog = true;
       

    }
    private void OnTriggerEnter(Collider other)
    {
        outOfFog = false;
    }
    void reduceHP()
    {
        float reducionNumber = timeInFog / reductionFactor;
        shipHealth -= reducionNumber;
        gameObject.GetComponent<ShipMov>().health = shipHealth;
        GameManager.instance.checkPlayerHP(shipHealth);
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {

    private float health;
    private float timeInFog;
    public float reductionFactor;

    [HideInInspector]
    public bool outOfFog;
    

    private void Update()
    {
        if (outOfFog)
        {
            timeInFog += Time.deltaTime;
            reduceHP();
        }
        Debug.Log(health);

    }
    private void Start()
    {
        timeInFog = 0;
        health = 100;
        outOfFog = false;
    }
    private void OnTriggerExit(Collider other)
    {
        outOfFog = true;
       

    }
    private void OnTriggerEnter(Collider other)
    {
        outOfFog = false;
    }
    void reduceHP()
    {
        float reducionNumber = timeInFog / reductionFactor;
        health -= reducionNumber;
    }
}
>>>>>>> d0b1199e2769c1b2555cbc1caa3bb17a49ac1af0
