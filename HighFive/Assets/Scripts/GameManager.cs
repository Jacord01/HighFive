using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour {
    public GameObject water;
    public NavMeshSurface surface;
    public bool cargaIslas = true;

    public GameObject hand = null;

    [SerializeField]
    public GameObject[] islands;

    // Use this for initialization
    void Start () {

        hand.transform.position = new Vector3(0, 0, 0);
        Instantiate(hand);
       int numIslands = Random.Range(60,100);
       
        for (int i = 0; i < numIslands; i++)
        {
            float posZ = Random.Range(10, water.transform.localScale.z);
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
                posZ *= -1;
            float posX = Random.Range(10, water.transform.localScale.x);
            int rnd2 = Random.Range(0, 2);
            if (rnd2 == 0)
                posX *= -1;

            int p = Random.Range(0, islands.Length);
            float y;
            if (p == 2 || p == 3)
                y = 2.35f;
            else y = 0;

            Vector3 v = new Vector3(posX, y, posZ);
            islands[p ].transform.position = v;
            Instantiate(islands[p]);
        }
        if(cargaIslas)
         surface.BuildNavMesh();

    }
	

}
