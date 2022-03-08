using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 3.5f;
    public GameObject player;
    public Rigidbody2D rb;
    public Camera cam;

    public GameObject rightGun;
    public GameObject leftGun;

    public Transform rightHand;
    public Transform leftHand;
    Vector2 movement;
    Vector2 mousePosition;

    void Start(){
        Instantiate(rightGun, rightHand);
        Instantiate(leftGun, leftHand);
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        cam.transform.rotation = Quaternion.Euler(Vector3.zero);

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }
}
