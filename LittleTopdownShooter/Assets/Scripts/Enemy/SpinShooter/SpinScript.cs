using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour , HealthScript
{
    public int maxHealth = 1000;
    public int currentHealth;

    public float rotateSpeed;

    void Start() {
        currentHealth = maxHealth;
    }

    void Update(){
        rotate();
    }

    void rotate() {
        gameObject.transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime, Space.World);
    }

    public void takeDamage(int damage){
        currentHealth = currentHealth -= damage;
        if(currentHealth <= 0){
            EnemySpawner.enemyAmount--;
            Destroy(gameObject);        
        }
    }
}
