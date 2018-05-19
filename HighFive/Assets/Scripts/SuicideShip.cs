using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideShip : MonoBehaviour {

	// Update is called once per frame
	void OnDestroy () {
        FindObjectOfType<ShipMov>().pierdeVida();
    }
}
