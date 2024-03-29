﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStar3 : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(speed, speed);
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        transform.Rotate(0, 0, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
