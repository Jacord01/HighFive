using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour {

    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);

            EnemyManager[] go = GameObject.FindObjectsOfType<EnemyManager>();

            foreach (EnemyManager g in go)
            {
                g.setFactor();
            }

            Destroy(gameObject);
        }           
    }
}
