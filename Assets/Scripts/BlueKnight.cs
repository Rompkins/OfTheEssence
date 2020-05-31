using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKnight : MonoBehaviour
{
    public Transform target;
    public bool facingRight;
    private Rigidbody2D rb;
    public float knightDistance;
    private Animator anim;

    public GameObject spellImpact;
    public GameObject blueKnightExplode;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        knightDistance = transform.position.x - target.transform.position.x;

        if (knightDistance < 5 && knightDistance > -5)
        {
            anim.SetBool("Shield", true);
        }
        else
        {
            anim.SetBool("Shield", false);
        }

        if (facingRight == false && target.position.x < rb.position.x)
        {
            flip();
        }
        else if (facingRight == true && target.position.x > rb.position.x)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spell"))
        {
            Destroy(gameObject);
            Instantiate(blueKnightExplode, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("PowerupNoise");
            Destroy(collision.gameObject);
            Instantiate(spellImpact, collision.transform.position, collision.transform.rotation);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Shroom"))
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
