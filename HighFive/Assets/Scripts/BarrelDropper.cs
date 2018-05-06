using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDropper : MonoBehaviour {

    public Transform dropper;
    public GameObject barrel;
    public float cooldown = 10f;

    bool canDrop = true;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canDrop) Drop();
        }
	}

    void Drop()
    {
        Instantiate(barrel, dropper.position, dropper.rotation);
        canDrop = false;
        Invoke("ActivateDrop", cooldown);
    }

    public void ActivateDrop()
    {
        canDrop = true;
    }

    public void DesactivaDrop()
    {
        canDrop = false;
    }
}
