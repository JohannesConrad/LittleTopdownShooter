using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooter : MonoBehaviour
{

    public Transform firepointMid;
    public Transform firepointLeft;
    public Transform firepointRight;
    public float fireRate;
    public GameObject projectile;
    private bool fireReady = true;

    void Update()
    {
        if(Input.GetButton("Fire1") && fireReady){
            fireReady = false;
            StartCoroutine(fireCooldown());
            Shoot();
        }
    }

    void Shoot() {
        Debug.Log("Fireeeee!");
        Instantiate(projectile, firepointMid);
        Instantiate(projectile, firepointLeft);
        Instantiate(projectile, firepointRight);
    }

    IEnumerator fireCooldown(){
        yield return new WaitForSeconds(fireRate);
        fireReady = true;
    }
}
