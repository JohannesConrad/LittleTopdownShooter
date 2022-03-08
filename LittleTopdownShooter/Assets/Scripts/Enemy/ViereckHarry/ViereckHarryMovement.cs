using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViereckHarryMovement : MonoBehaviour , ReferencingPlayer{
    public float speed = 5f;
    private Rigidbody2D rb;
    public Vector2 direction;
    public bool lineOfSightToPlayer;
    public bool inRangeOfPlayer;
    private bool fireReady = true;
    public float fireRate = 4.0f;
    public GameObject viereck;
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
                    Vector2 directionRaw = player.transform.position - gameObject.transform.position;
                    direction = directionRaw.normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
                    rb.rotation = angle;

                    if(fireReady && directionRaw.magnitude < 5.0f){
                        fireReady = false;
                        Instantiate(viereck, player.transform.position, player.transform.rotation);
                        StartCoroutine(fireCooldown());
                    }
                }else{
                    lineOfSightToPlayer = false;
                }
        }
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
    IEnumerator fireCooldown(){
        yield return new WaitForSeconds(fireRate);
        fireReady = true; 
    }

    public void setPlayer(GameObject inputPLayer){
        player = inputPLayer;
    }
}
