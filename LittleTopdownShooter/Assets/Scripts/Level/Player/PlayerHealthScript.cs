using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour, PlayerHealthInterface{
    public int maxHealth;
    int currentHealth;

    void Start(){
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
