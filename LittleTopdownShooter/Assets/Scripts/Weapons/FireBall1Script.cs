using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall1Script : MonoBehaviour {
    public Rigidbody2D rb;
    public float thrust;
    public int damage;

    void Start(){
        rb.AddForce(rb.transform.up * thrust);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(!collision.isTrigger){
            HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();
            if (healthScript != null) {
                healthScript.takeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
