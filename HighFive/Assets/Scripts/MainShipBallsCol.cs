using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShipBallsCol : MonoBehaviour {

	 private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Cannonball>() )
        {
            other.GetComponent<Cannonball>().Collision();
            GetComponentInParent<ShipMov>().pierdeVida();

        }

        else if (other.GetComponent<Barrell>())
        {
            other.GetComponent<Barrell>().Collision();
            GetComponentInParent<ShipMov>().pierdeVida();

        }
    }
}
