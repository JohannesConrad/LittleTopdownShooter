using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour , HealthScript {
    public Transform playerPosition;
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 1f;
    public int maxHealth = 300;
    private int currentHealth;

    void Start(){
        currentHealth = maxHealth;
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void takeDamage(int damage){
        currentHealth = currentHealth -= damage;
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){
        Vector2 newDirection = -this.transform.position;
        m_Rigidbody.AddForce(newDirection.normalized * m_Thrust);
    }
}
