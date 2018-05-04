using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{

    GameObject target = null;
    public NavMeshAgent player;

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(target);
        if(target != null)
        player.SetDestination(target.transform.position);

         // player.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {

       // Debug.Log("Hemos entrado");
        if (other.GetComponent<ShipMov>()) {
            int aux = Random.Range(0, 2);
            if (aux == 0)
            {
              target =  other.GetComponent<ShipMov>().getSP1();
            }
            else
              target =  other.GetComponent<ShipMov>().getSP2();

        }
    }
}