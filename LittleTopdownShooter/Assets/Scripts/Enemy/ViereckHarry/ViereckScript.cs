using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViereckScript : MonoBehaviour{
    public int damageToPlayer;
    public int damageToOther;
    public float windupTime;
    public float lingerTime;
    public SpriteRenderer sr;
    public Collider2D col;

    void Start(){
        StartCoroutine(windup());

    }

    IEnumerator windup () {
        yield return new WaitForSeconds(windupTime);
        StartCoroutine(damageAndVanish());
    }

    IEnumerator damageAndVanish(){
        col.enabled = true;
        sr.color = new Color(0,201,212,130);
        List<Collider2D> hits = new List<Collider2D>();
        col.OverlapCollider(new ContactFilter2D(), hits);
        foreach(Collider2D hit in hits){
            HealthScript nonPlayerHealth = hit.gameObject.GetComponent<HealthScript>();
            PlayerHealthInterface playerHealth = hit.gameObject.GetComponent<PlayerHealthInterface>();
            if(nonPlayerHealth != null){
                nonPlayerHealth.takeDamage(damageToOther);
            }
            if(playerHealth != null){
                playerHealth.takeDamage(damageToPlayer);
            }
        }
        yield return new WaitForSeconds(lingerTime);
        Destroy(gameObject);
    }
}
