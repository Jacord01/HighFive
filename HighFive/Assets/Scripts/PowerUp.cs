using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Pickup();
        }           
    }

    void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // incrementar velocidad de player
        // incrementar tiempo restante
        // incrementar potencia de fuego

        Destroy(gameObject);
    }
}
