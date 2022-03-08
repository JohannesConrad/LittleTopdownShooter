using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour , IPlayerPickup{

    public int goldenAmount;

    public void pickupGolden(int amount){
        goldenAmount += amount;
    }

}
