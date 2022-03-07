using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour , HealthScript {
    public Material empty;
    public Material breakable;
    public Material unbreakable;
    public Rigidbody2D rb;

    public int maxHealth = 1000;
    public int currentHealth;

    private int type = 0;

    void Start() {
        currentHealth = maxHealth;
    }

    public void setEmpty() {
        type = 0;
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.GetComponent<SpriteRenderer>().material = empty;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void setBreakable() {
        type = 1;
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.GetComponent<SpriteRenderer>().material = breakable;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void setUnbreakable() {
        type = 2;
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.GetComponent<SpriteRenderer>().material = unbreakable;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    public bool isUnbreakable() {
        return type == 2;
    }

    public void takeDamage(int damage){
        if(type == 1) {
            currentHealth = currentHealth -= damage;
            if(currentHealth <= 0){
                this.setEmpty();
            }
        }
    }

    public bool isEmptyTile() {
        return type == 0;
    }
}
