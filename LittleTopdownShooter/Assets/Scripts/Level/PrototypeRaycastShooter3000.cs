using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeRaycastShooter3000 : MonoBehaviour
{

    public Transform firePoint;
    public GameObject hitEffect;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot() {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position,firePoint.up);
        Debug.Log("shot");
        if(hitInfo){
            HealthScript healthScript = hitInfo.transform.GetComponent<HealthScript>();
            Debug.Log("hit");
            if(healthScript != null){
                Debug.Log("hit sth with health");
                healthScript.takeDamage(100);
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
}
