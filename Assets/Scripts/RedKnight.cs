using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedKnight : MonoBehaviour
{
    public Transform target;
    public bool facingRight;
    private Rigidbody2D rb;
    public float knightDistance;
    private Animator anim;
    public GameObject redKnightText;
    public bool showingText = false;
    public bool hasTenHearts = false;
    public Health health;
    public GameObject redKnightExplode;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.numOfHearts == 10)
        {
            hasTenHearts = true;
        }

        knightDistance = transform.position.x - target.transform.position.x;

        if(knightDistance <5 && knightDistance > -5)
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && showingText == false && hasTenHearts == false)
        {
            StartCoroutine(RedKnightText());
        }
        else if(collision.collider.CompareTag("Player") && hasTenHearts == true)
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("PowerupNoise");
            Instantiate(redKnightExplode, transform.position, transform.rotation);
        }
    }

    public IEnumerator RedKnightText()
    {
        showingText = true;
        redKnightText.SetActive(true);
        yield return new WaitForSeconds(7);
        redKnightText.SetActive(false);
        showingText = false;

    }
}
