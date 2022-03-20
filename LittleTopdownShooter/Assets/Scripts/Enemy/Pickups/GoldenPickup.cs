using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPickup : MonoBehaviour {
    public int amount;
    void Start() {
        amount = Random.Range(30,70);
    }
    void OnTriggerEnter2D(Collider2D col){
        PlayerHealthInterface player = col.transform.gameObject.GetComponent<PlayerHealthInterface>();
        if(player != null){
            Debug.Log("Something detected!");
            PlayerStateManager.goldenAmount += amount;
            Destroy(gameObject);
        }
    }
}
