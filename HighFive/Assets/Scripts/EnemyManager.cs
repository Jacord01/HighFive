<<<<<<< HEAD
﻿using System.Collections;
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
            int p = Random.Range(0, 4);
            Debug.Log(p);

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
        else Debug.Log("EL DROP ELEMENT ES NULL");
    }

    public void pierdeVida()
    {
        lives -= looseFactor;
        Debug.Log("VIDAS" + lives);
        if (lives <= 0)
        {
            
            loosing = true;
            gonnaDestroy();

        }
    }

    void gonnaDestroy()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        drop();
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
        Invoke("RestoreFactor", 30f);
    }

    void RestoreFactor()
    {
        looseFactor /= 2;
    }
}

=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public int lives = 10;
    public bool loosing = false;
    int giro = 8;
   
    [SerializeField]
    public Transform[] wheres;
    public GameObject DropElement = null;
   
    private void FixedUpdate()
    {
        if (loosing)
        {

            gameObject.transform.Rotate(giro * Time.deltaTime, 0, 0);
            gameObject.GetComponent<FLoatObjectScript>().changeDownForce(0.1f);
           
        }
    }

    void drop()
    {

        if (DropElement != null)
        {
            int p = Random.Range(0, 4);
            Debug.Log(p);

            for (int i = 0; i < p; i++)
            {
                GameObject aux = Instantiate(DropElement, wheres[i]);
                aux.transform.SetParent(null);
               
            }
        }
        else Debug.Log("EL DROP ELEMENT ES NULL");
    }

    public void pierdeVida()
    {
        lives -= 1;
        if (lives <= 0)
        {
            drop();
            loosing = true;
            GetComponent<NavMeshAgent>().enabled = false;
            Invoke("gonnaDestroy", 2f);

        }
    }

    void gonnaDestroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        drop();
    }
}
>>>>>>> d0b1199e2769c1b2555cbc1caa3bb17a49ac1af0
