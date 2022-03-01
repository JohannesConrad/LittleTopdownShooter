using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeRaycastShooter3000 : MonoBehaviour
{

    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position,firePoint.up);
        Debug.Log("shot");
        if(hitInfo){
            HealthScript healthScript = hitInfo.transform.GetComponent<HealthScript>();
            Debug.Log("hit");
            if(healthScript != null){
                Debug.Log("hit sth with health");
                healthScript.takeDamage(100);
            }
        }
    }
}
