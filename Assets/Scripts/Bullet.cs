using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 05f;
    public Rigidbody2D rb;
    public int damage = 40;
    public int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
        if (this.tag == "bullet")
        {
            rb.velocity = transform.right * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);

        enemyTest enemy = other.GetComponent<enemyTest>();

        if (enemy != null)
        {
            int damage = 100;
            if (this.tag == "bullet" && enemy.CompareTag("enemy"))
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
                score++;
            }
            }
    }
}
