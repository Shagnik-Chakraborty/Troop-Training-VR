using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform launchPoint;
    public float bulletSpeed = 10.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LaunchBullet();
        }
    }

    void LaunchBullet()
    {
        if (bulletPrefab == null || launchPoint == null)
        {
            Debug.LogError("Bullet prefab or launch point not set.");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, launchPoint.position, launchPoint.rotation);

        // Access the bullet's rigidbody and give it an initial velocity.
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab must have a Rigidbody component.");
        }
    }
}
