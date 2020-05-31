using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed = 75;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        FindObjectOfType<AudioManager>().Play("CreditsMusic");
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.transform.position.y >= 2150)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
