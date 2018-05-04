using System.Collections;
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
