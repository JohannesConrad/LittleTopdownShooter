using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeRaycastShooter3000 : MonoBehaviour
{

    public Transform firePoint;
    public GameObject hitEffect;
    public LineRenderer lineRenderer;
    public int damage;
    public float fireRate = 0.4f;
    private bool fireReady = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && fireReady){
            fireReady = false;
            StartCoroutine(fireCooldown());
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot() {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position,firePoint.up);
        if(hitInfo){
            HealthScript healthScript = hitInfo.transform.GetComponent<HealthScript>();
            if(healthScript != null){
                healthScript.takeDamage(damage);
            }
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }else{
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.up * 100);
        }
        Instantiate(hitEffect, hitInfo.point, Quaternion.identity);
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.03f);
        lineRenderer.enabled = false;
    }

    IEnumerator fireCooldown(){
        yield return new WaitForSeconds(fireRate);
        fireReady = true;
    }
}
