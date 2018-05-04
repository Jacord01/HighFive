using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject bullet;
    public float cooldown = 2f;

    bool canShoot = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot) Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        canShoot = false;
        Invoke("ActivateShoot", cooldown);
    }

    void ActivateShoot()
    {
        canShoot = true;
    }
}
