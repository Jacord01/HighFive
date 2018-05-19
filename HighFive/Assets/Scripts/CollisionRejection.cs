using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRejection : MonoBehaviour {

    public float distance = 3;
	void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ShipMov>())
        {
            other.transform.position = new Vector3(other.transform.position.x -distance, other.transform.position.y, other.transform.position.z - distance);
        }
    }
}
