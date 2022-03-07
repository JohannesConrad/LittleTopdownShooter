using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWalterMovement : MonoBehaviour , ReferencingPlayer{

    public Collider2D rangeCircle;
    public float speed = 5f;
    private Rigidbody2D rb;
    public Vector2 direction;
    public bool lineOfSightToPlayer;
    private bool fireReady = true;
    public float fireRate = 2.0f;
    public Transform firepoint;
    public GameObject rocket;
    public GameObject player;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision){
        direction = (collision.contacts[0].normal + new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))).normalized;
        if(!lineOfSightToPlayer){
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
            rb.rotation = angle;        
        }
    }
    void FixedUpdate(){
        Vector3 eyes = gameObject.transform.position + new Vector3(0, 0.7f, 0);
        RaycastHit2D hitInfo = Physics2D.Raycast(eyes, player.transform.position - eyes);
        if(hitInfo){
                if(hitInfo.transform.gameObject.GetComponent<PlayerHealthInterface>() != null){
                    lineOfSightToPlayer = true;
                    direction = (player.transform.position - gameObject.transform.position).normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
                    rb.rotation = angle;
                    if(fireReady){
                        fireReady = false;
                        StartCoroutine(fireRocket());
                    }
                }else{
                    lineOfSightToPlayer = false;
                }
        }
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
    IEnumerator fireRocket(){
        yield return new WaitForSeconds(0.1f);
        Instantiate(rocket, firepoint.position, firepoint.rotation);
        StartCoroutine(fireCooldown());
    }

    IEnumerator fireCooldown(){
        yield return new WaitForSeconds(fireRate);
        fireReady = true; 
    }

    public void setPlayer(GameObject inputPLayer){
        player = inputPLayer;
    }
}
