<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{

    GameObject target = null;
    public NavMeshAgent player;
    public bool smallBoat = false;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ShipMov>()) {
            int aux = Random.Range(0, 2);
            if (aux == 0)
            {
              target =  other.GetComponent<ShipMov>().getSP1();
            }
            else
              target =  other.GetComponent<ShipMov>().getSP2();

            gameObject.GetComponent<EnemyManager>().fightin();
        }
    }
=======
﻿using System.Collections;
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
>>>>>>> d0b1199e2769c1b2555cbc1caa3bb17a49ac1af0
}