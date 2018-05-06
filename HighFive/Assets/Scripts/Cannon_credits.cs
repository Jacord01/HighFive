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
        if ((Input.GetKeyDown(KeyCode.Q)) || (Input.GetButtonDown("XBox_X")) || (Input.GetButtonDown("XBox_LeftBumper")))
        {
            if (canShoot) ShootLeft();
        }

        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("XBox_B")) || (Input.GetButtonDown("XBox_RightBumper")))
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
