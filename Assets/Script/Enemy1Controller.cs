using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    public int enemyHealth = 2;
    public float moveSpeed = 2.0f;
    private Vector3 direction = Vector3.right;
    private float changeDirectionTimer = 4.0f;
    private float timer;

    void Start()
    {
        timer = changeDirectionTimer;
    }

    void Update()
    {
        Move();

        // Actualizar el temporizador y cambiar de dirección cuando se agote
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeDirection();
            timer = changeDirectionTimer; // Reiniciar el temporizador
        }
    }

    void Move()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        // Cambiar la dirección cada 4 segundos
        direction = -direction;
    }

    public void DamageEnemy(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    
}
