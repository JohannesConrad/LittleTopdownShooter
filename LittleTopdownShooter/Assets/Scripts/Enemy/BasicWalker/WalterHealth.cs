using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalterHealth : MonoBehaviour , HealthScript
{

    public int maxHealth = 300;
    private int currentHealth;

    void Start(){
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage){
        currentHealth = currentHealth -= damage;
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }

}
