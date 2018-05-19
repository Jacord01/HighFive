using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public int lives = 3;
    public bool loosing = false;
    bool figth = false;
    public int looseFactor = 1;

    [SerializeField]
    public Transform[] wheres;
    public GameObject DropElement = null;
    public GameObject DropElement2 = null;


    void drop()
    {

        if (DropElement != null)
        {
            int p = Random.Range(1, 4);
           
            for (int i = 0; i < p; i++)
            {
                GameObject aux;
                int rnd = Random.Range(0, 2);
                if (rnd == 0)
                {
                    aux = Instantiate(DropElement, wheres[i]);
                    GameManager.instance.addPiratesToScore(1);
                }
                else
                {
                    aux = Instantiate(DropElement2, wheres[i]);
                    GameManager.instance.addPiratesToScore(2);
                }
                GameManager.instance.addPiratesToScore(2);
                aux.transform.SetParent(null);

            }
        }
        else Debug.LogWarning("EL DROP ELEMENT ES NULL");
    }

    public void pierdeVida()
    {
        lives -= looseFactor;
       
        if (lives <= 0 && !loosing)
        {
            
            loosing = true;
            gonnaDestroy();

        }
    }

    void gonnaDestroy()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        drop();
        FindObjectOfType<GameManager>().createShip();
        Destroy(gameObject);
    }

    public void fightin()
    {
        figth = true;
    }
    public bool getfight() { return figth; }

    public void setFactor()
    {
        looseFactor *= 2;
        Invoke("RestoreFactor", 10f);
    }

    void RestoreFactor()
    {
        looseFactor /= 2;
    }
}

