using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public int lives = 10;

    [SerializeField]
    public Transform[] wheres;

    //public Transform whereToDrop1;
    //public Transform whereToDrop2;
    //public Transform whereToDrop3;
    //public Transform whereToDrop4;

    public GameObject DropElement = null;

    private void Start()
    {
        drop();
    }

    // Update is called once per frame
    void Update () {
      
	}

    void drop()
    {
       
        int p = Random.Range(0, 4);
        Debug.Log(p);

        for (int i = 0; i < p; i++)
        {
            Instantiate(DropElement, wheres[i]);

        }

    }
}
