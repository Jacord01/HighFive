using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBoatCollider : MonoBehaviour {

    void onTriggerEnter(Collider other)
    {

        Debug.Log("Eh");
        if (other.GetComponent<ShipMov>())
            Destroy(this.gameObject);
    }
}
