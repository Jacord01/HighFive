using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball: MonoBehaviour {

    public GameObject explosionEffect;
    public float explosionRadius = 10f;
    public float explosionForce = 700f;
    public float firePower = 2000f;

    bool hasExploded = false;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * firePower);

        Invoke("destroyMe", 5f);
    }

    public void Collision()
    {

            hasExploded = true;
            Explode();

    }

    void Explode()
    {
        // Show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Add force
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
            
        }
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);

        // Destroy object
        Destroy(gameObject);
    }

    void destroyMe()
    {
        Destroy(gameObject);
    }
}
