using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileImpact : MonoBehaviour
{
    public int damage = 500;

    void OnTriggerEnter2D(Collider2D collision){
        HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();
        if (healthScript != null) {
            healthScript.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
