using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Cannonball>())
        {
            other.GetComponent<Cannonball>().Collision();
            GetComponentInParent<EnemyManager>().pierdeVida();
        }
    }
}

