using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour, PlayerHealthInterface{
    public int maxHealth;
    int currentHealth;
    public Slider slider;

    void Start(){
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        slider.minValue = 0;
    }

    public void takeDamage(int damage){
        currentHealth -= damage; 
        slider.value = currentHealth;
        if(currentHealth <= 0){
            EnemySpawner.enemyAmount = 0;
            Destroy(gameObject);
        }
    }
}
