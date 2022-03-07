using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaltersRaketenscript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float thrust;
    public GameObject explosion;
    void FixedUpdate(){
        rb.AddForce(rb.transform.up * thrust);
    }

    void OnCollisionEnter2D(Collision2D collision){
        Instantiate(explosion, rb.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
