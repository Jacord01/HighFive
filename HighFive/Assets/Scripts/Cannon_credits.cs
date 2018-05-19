using UnityEngine;

public class Cannon_credits : MonoBehaviour {

    public Transform[] cannonsRight;
    public Transform[] cannonsLeft;
    public Cannonball bulletRight;
    public Cannonball bulletLeft;
    public float cooldown = 2f;

    bool canShoot = true;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Q)))
        {
            if (canShoot) ShootLeft();
        }

        if ((Input.GetKeyDown(KeyCode.E)))
        {
            if (canShoot) ShootRight();
        }
    }

    void ShootRight()
    {
        foreach (Transform t in cannonsRight)
        {
            Instantiate(bulletRight, t.position, transform.rotation);
        }

        canShoot = false;
        Invoke("ActivateShoot", cooldown);
    }

    void ShootLeft()
    {
        foreach (Transform t in cannonsLeft)
        {
            Instantiate(bulletLeft, t.position, transform.rotation);
        }

        canShoot = false;
        Invoke("ActivateShoot", cooldown);
    }

    void ActivateShoot()
    {
        canShoot = true;
    }
}
