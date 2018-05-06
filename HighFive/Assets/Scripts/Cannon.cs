using UnityEngine;

public class Cannon : MonoBehaviour
{

    public Transform[] cannonsRight;
    public Transform[] cannonsLeft;
    public Cannonball bulletRight;
    public Cannonball bulletLeft;
    public float cooldown = 2f;
    Transform FirstPos;
    BarrelDropper barrelDrop;

    bool canShoot = true;

    private void Start()
    {
        FirstPos = this.gameObject.transform.GetChild(0).transform;
        barrelDrop = this.gameObject.GetComponent<BarrelDropper>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //  if (canShoot) ShootLeft();
            this.gameObject.transform.GetChild(0).transform.position =
                                        this.gameObject.transform.GetChild(11).transform.position;

            this.gameObject.transform.GetChild(0).transform.rotation =
                                        this.gameObject.transform.GetChild(11).transform.rotation;

            barrelDrop.DesactivaDrop();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //  if (canShoot) ShootRight();
            this.gameObject.transform.GetChild(0).transform.position =
                                         this.gameObject.transform.GetChild(12).transform.position;

            this.gameObject.transform.GetChild(0).transform.rotation =
                                        this.gameObject.transform.GetChild(12).transform.rotation;
            barrelDrop.DesactivaDrop();
        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            this.gameObject.transform.GetChild(0).transform.position =
                                        this.gameObject.transform.GetChild(13).transform.position;

            this.gameObject.transform.GetChild(0).transform.rotation =
                                        this.gameObject.transform.GetChild(13).transform.rotation;
            barrelDrop.ActivateDrop();
        }

        if (Input.GetKey(KeyCode.Q) && canShoot && Input.GetKeyDown(KeyCode.Space)) { ShootLeft(); }
        else if (Input.GetKey(KeyCode.E) && canShoot && Input.GetKeyDown(KeyCode.Space)) { ShootRight(); }
    }

    void ShootRight()
    {
        foreach (Transform t in cannonsRight)
        {
            Instantiate(bulletRight, t.position, transform.rotation);
        }
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        canShoot = false;
        Invoke("ActivateShoot", cooldown);
    }

    void ShootLeft()
    {
        foreach (Transform t in cannonsLeft)
        {
            Instantiate(bulletLeft, t.position, transform.rotation);
        }
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        canShoot = false;
        Invoke("ActivateShoot", cooldown);
    }

    void ActivateShoot()
    {
        canShoot = true;
    }
}