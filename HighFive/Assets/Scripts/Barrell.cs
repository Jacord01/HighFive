using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrell : MonoBehaviour {

    public GameObject explosionEffect;
    public float explosionRadius = 20f;
    public float explosionForce = 1400f;

    bool hasExploded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ShipMov>() || other.gameObject.GetComponent<EnemyManager>())
        {
            if (!hasExploded)
            {
                Debug.Log("EXPLODING!");
                hasExploded = true;
                Explode();

                if (other.gameObject.GetComponent<ShipMov>())
                {
                    other.gameObject.GetComponent<ShipMov>().pierdeVida();
                }

                else
                    other.gameObject.GetComponent<EnemyManager>().pierdeVida();
            }
        }
    }

    void Explode()
    {
        // Show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Add force
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

        }

        // Destroy object
        Destroy(gameObject);
    }
}
