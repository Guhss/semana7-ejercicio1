using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de Bala1
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10.0f; // Velocidad inicial de la bala
    public float fireRate = 1.0f; 
    public float Speedmovement = 5.0f;
    public float Speedrotation = 200.0f;
    public float x, y;

    private float nextFireTime;
    private int playerLevel = 1;

    void Start()
    {

    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * Speedrotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * Speedmovement);

        if (Input.GetKeyDown(KeyCode.K) && Time.time > nextFireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 shootingDirection = transform.forward; // La dirección es la misma que la del jugador

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = shootingDirection * bulletSpeed;

        nextFireTime = Time.time + 1.0f / (fireRate + playerLevel); // Aumenta la velocidad de disparo con el nivel
    }

    public void IncreaseLevel()
    {
        playerLevel++; 
        fireRate *= 0.9f; 
    }
}
