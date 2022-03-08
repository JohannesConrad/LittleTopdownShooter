using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalterHealth : MonoBehaviour , HealthScript
{

    public int maxHealth = 300;
    private int currentHealth;
    public GameObject goldenDrop;

    void Start(){
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage){
        currentHealth = currentHealth -= damage;
        if(currentHealth <= 0){
            dropLoot();
            Destroy(gameObject);
        }
    }

    private void dropLoot(){
        int dropAmount = Random.Range(0,3);
        for(int i = 0; i < dropAmount; i++){
            Instantiate(goldenDrop, gameObject.transform.position + new Vector3(Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f), 0), Quaternion.identity);
        }
    }

}
