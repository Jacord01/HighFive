using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoatOccupation : MonoBehaviour {

    bool occupied = false;
 
     public  bool getOccupied()
    {
        return occupied;
    }

    void setOccupied(bool t)
    {
        occupied = t;
    }
}
