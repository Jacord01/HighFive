using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRejection : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ShipMov>())
        {
            other.transform.position = new Vector3(other.transform.position.x -3f, other.transform.position.y, other.transform.position.z -3f);
        }
    }
}
