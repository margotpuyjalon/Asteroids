using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    // Spawner variables
    public Vector2 direction;
    public float speed;

    void Update()
    {
        transform.Translate(direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision.GetComponent<Player>().health -= damage;
        // Debug.Log(collision.GetComponent<Player>().health);
        Destroy(gameObject);
    }
}
