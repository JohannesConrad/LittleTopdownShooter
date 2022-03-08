using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPickup : MonoBehaviour {
    public int amount;
    void Start() {
        amount = Random.Range(30,70);
    }
    void OnTriggerEnter2D(Collider2D col){
        IPlayerPickup player = col.transform.gameObject.GetComponent<IPlayerPickup>();
        if(player != null){
            Debug.Log("Something detected!");
            player.pickupGolden(amount);
            Destroy(gameObject);
        }
    }

}
