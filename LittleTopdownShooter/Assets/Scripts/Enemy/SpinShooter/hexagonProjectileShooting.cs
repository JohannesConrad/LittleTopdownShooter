using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexagonProjectileShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed;
    void Start() {
        StartCoroutine(shootAndRepeat());
    }

    IEnumerator shootAndRepeat() {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Nun wird der Böppel instanziiert und beschleunigt.");
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * projectileSpeed);
        StartCoroutine(shootAndRepeat());
    }
}
