using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCannion : MonoBehaviour {

    public Transform[] cannonsRight;
    public Transform[] cannonsLeft;
    public Cannonball bulletRight;
    public Cannonball bulletLeft;
    public float cooldown = 2f;

    bool canShoot = true;

    private void Update()
    {
        
        if (gameObject.GetComponent<EnemyManager>().getfight())
        {
            if (canShoot)
            {
                ShootRight();
                ShootLeft();
                canShoot = false;
                Invoke("ActivateShoot", cooldown);
            }
        }
    }

    void ShootRight()
    {
     
        foreach (Transform t in cannonsRight)
        {
           
            Instantiate(bulletRight, t.position, transform.rotation);
           // Debug.Log("Instantiated");
        }

        
      
    }

    void ShootLeft()
    {
        foreach (Transform t in cannonsLeft)
        {
            Instantiate(bulletLeft, t.position, transform.rotation);
        }

  
  
    }

    void ActivateShoot()
    {
        canShoot = true;
    }
}
