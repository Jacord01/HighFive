using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveToTarget : MonoBehaviour
{
    private bool entered_ = false;

    GameObject target = null;
    GameObject auxTarget = null;
    public NavMeshAgent player;
    public bool smallBoat = false;
    bool SP1 = false;
    bool SP2 = false;

    private void Start()
    {
        if (smallBoat)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(target);
        if(target != null)
            player.SetDestination(target.transform.position);
        if(smallBoat)
            player.SetDestination(target.transform.position);
        // player.SetDestination(player.transform.position);
    }

    private void OnDestroy()
    {
        if (SP1)
        {
            FindObjectOfType<ShipMov>().setSP(1, false);
        }
        else if (SP2)
        {
            FindObjectOfType<ShipMov>().setSP(2, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!entered_ && other.GetComponent<ShipMov>()) {
            entered_ = true;

            target = other.GetComponent<ShipMov>().getSP1();
            auxTarget = other.GetComponent<ShipMov>().getSP2();

            float dist = Vector3.Distance(target.transform.position, transform.position);
            float dist2 = Vector3.Distance(auxTarget.transform.position, transform.position);

            if (dist2 < dist)
            {
                if (!other.GetComponent<ShipMov>().getSP2State())
                {
                    target = auxTarget;
                    other.GetComponent<ShipMov>().setSP(2, true);
                    SP2 = true;
                    gameObject.GetComponent<EnemyManager>().fightin();
                }
            }
            else
            {
                if (!other.GetComponent<ShipMov>().getSP1State())
                {
                    other.GetComponent<ShipMov>().setSP(1, true);
                    SP1 = true;
                    gameObject.GetComponent<EnemyManager>().fightin();
                }
            }
            
        }
    }
}