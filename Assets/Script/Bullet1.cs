using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float destroyTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            Destroy(gameObject); 
        }
    }
}
