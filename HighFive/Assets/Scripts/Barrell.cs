<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrell : MonoBehaviour {

    public GameObject explosionEffect;
    public float explosionRadius = 20f;
    public float explosionForce = 1400f;

    bool hasExploded = false;

    public void Collision()
    {
        if (!hasExploded)
        {
            Debug.Log("EXPLODING!");
            hasExploded = true;
            Explode();
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
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrell : MonoBehaviour {

    public GameObject explosionEffect;
    public float explosionRadius = 20f;
    public float explosionForce = 1400f;

    bool hasExploded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            hasExploded = true;
            Explode();
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
>>>>>>> d0b1199e2769c1b2555cbc1caa3bb17a49ac1af0
