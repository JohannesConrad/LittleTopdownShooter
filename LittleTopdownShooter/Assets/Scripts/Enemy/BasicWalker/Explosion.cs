using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour{

    public CircleCollider2D explosionZone;
    public int damageToPlayer;
    public int damageToOther;

    void Start(){
        List<Collider2D> hits = new List<Collider2D>();
        explosionZone.OverlapCollider(new ContactFilter2D(), hits);
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
        StartCoroutine(fade());
    }

    IEnumerator fade () {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
