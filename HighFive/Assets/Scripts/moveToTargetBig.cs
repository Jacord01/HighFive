using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class moveToTargetBig : MonoBehaviour {

    GameObject target = null;
    public NavMeshAgent player;
    // Use this for initialization
    private void Start()
    {
       
            target = GameObject.FindGameObjectWithTag("Player");
     
    }

    // Update is called once per frame
    void Update () {
        player.SetDestination(target.transform.position);
    }
}
