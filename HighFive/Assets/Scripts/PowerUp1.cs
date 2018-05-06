using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1 : MonoBehaviour {

    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);

            other.gameObject.GetComponent<ShipMov>().AddHealth();
            

            Destroy(gameObject);
        }           
    }
}
