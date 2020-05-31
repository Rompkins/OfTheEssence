using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public int health;
    public float speed;

    public Animator anim;

    public float startDazedTime;
    private float dazedTime;

    private Transform target;

    private bool facingRight = true;
    public Rigidbody2D rb;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();        
    }

    private void FixedUpdate()
    {
        if (facingRight == false && target.position.x < rb.position.x)
        {
            flip();
        }
        else if (facingRight == true && target.position.x > rb.position.x)
        {
            flip();
        }
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(dazedTime <= 0)
        {
            speed = 2;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        anim.SetTrigger("Hurt");

        health -= damage;
        Debug.Log("Damage Taken");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");
        anim.SetBool("IsDead", true);
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 5);
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
