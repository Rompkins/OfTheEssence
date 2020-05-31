using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public float normalSpeed;

    public Animator anim;
    private Animator camAnim;

    public float startDazedTime;
    private float dazedTime;
    public bool skeleton;
    public bool flyingEye;
    public bool mushroom;
    public bool goblin;
    public bool skeletonWalk;
    public bool isKing;

    private Transform target;
    private BTPMovement playerScript;
    private Health playerHealth;

    private bool facingRight = true;

    public Rigidbody2D rb;

    public GameObject spellImpact;

    public bool mushroomCanAttack = true;
    public GameObject mushroomProjectile;
    public Transform mushroomFirePoint;
    public bool mushroomDistance = false;

    public float mushroomDistanceNum;

    public bool skeletonCanAttack = true;
    public bool skeletonDistance = false;
    public float skeletonDistanceNum;

    public float kingDistanceNumX;
    public float kingDistanceNumY;
    public bool kingCanSlam = true;
    public bool kingCanCast = false;
    public bool kingDistance = false;
    public bool kingCastCooldown = true;
    public bool kingSlamCooldown = true;

    public GameObject[] enemy;
    public int rand;
    public Transform bossSpawnPoint;

    public Transform bossFirePoint;
    public GameObject bossStar1;
    public GameObject bossStar2;
    public GameObject bossStar3;
    public GameObject bossStar4;
    public GameObject bossStar5;


    public int randomItem;
    public GameObject heartHealth;
    public GameObject magicPotion;
    public PlayerAttack playerAttack;

    public PauseMenu pauseMenu;

    private void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        playerScript = GameObject.Find("Player").GetComponent<BTPMovement>();
        playerHealth = GameObject.Find("Player").GetComponent<Health>();

        randomItem = Random.Range(0, 5);
    }


    private void FixedUpdate()
    {
        if (skeleton == true || skeletonWalk == true || goblin == true || flyingEye == true || mushroom == true || isKing == true)
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
    }

    void Update()
    {
        mushroomDistanceNum = transform.position.x - target.transform.position.x;
        skeletonDistanceNum = transform.position.x - target.transform.position.x;
        kingDistanceNumX = transform.position.x - target.transform.position.x;
        kingDistanceNumY = transform.position.y - target.transform.position.y;

        if (kingDistanceNumX < 10 && kingDistanceNumX > -10 && kingDistanceNumY < 10 && kingDistanceNumY > -10)
        {
            kingDistance = true;
        }
        else
        {
            kingDistance = false;
        }

        if (mushroomDistanceNum < 10 && mushroomDistanceNum > -10)
        {
            mushroomDistance = true;
        }
        else
        {
            mushroomDistance = false;
        }

        if (skeletonDistanceNum < 3 && skeletonDistanceNum > -3)
        {
            skeletonDistance = true;
        }
        else
        {
            skeletonDistance = false;
        }

        if (skeleton == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (skeletonCanAttack == true && skeletonDistance == true)
            {
                StartCoroutine(SkeletonAttack());
            }
        }

        if (skeletonWalk == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (skeletonCanAttack == true && skeletonDistance == true)
            {
                StartCoroutine(SkeletonAttack());
            }
        }

        if (flyingEye == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (mushroom == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (mushroomCanAttack == true && mushroomDistance == true)
            {
                StartCoroutine(MushroomAttack());
            }
        }

        if (goblin == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (isKing == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (kingCanSlam == true && kingDistance == true && kingSlamCooldown == false)
            {
                StartCoroutine(KingSlam());
                StartCoroutine(KingCastCooldown());
            }

            if (kingCanCast == true && kingCanSlam == false && kingCastCooldown == false)
            {
                StartCoroutine(KingCast());
                StartCoroutine(KingSlamCooldown());
            }
        }


        if (dazedTime <= 0)
        {
            speed = normalSpeed;
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
        camAnim.SetTrigger("Shake");
        health -= damage;
        Debug.Log("Damage Taken");

        if (health <= 0 && isKing == true)
        {
            pauseMenu.endGame = true;
            Die();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetBool("IsDead", true);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;

        if(skeleton == true || skeletonWalk == true)
        {
            StartCoroutine(BonesCrack());
        }

        if (goblin == true)
        {
            FindObjectOfType<AudioManager>().Play("GoblinDeath");
        }

        if (mushroom == true)
        {
            FindObjectOfType<AudioManager>().Play("MushroomDeath");
        }


        if (flyingEye == true)
        {
            FindObjectOfType<AudioManager>().Play("FlyingEyeDeath");
        }

        if (!isKing)
        {
            if (randomItem == 1)
            {
                Instantiate(heartHealth, transform.position, transform.rotation);
            }
            else if (randomItem == 2 && playerAttack.canMagic == true)
            {
                Instantiate(magicPotion, transform.position, transform.rotation);
            }
        }
            Destroy(gameObject, 3);
       
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
            TakeDamage(10);
            Destroy(collision.gameObject);
            Instantiate(spellImpact, collision.transform.position, collision.transform.rotation);
        }

        if (collision.CompareTag("PlayerCollider") && playerScript.hitTimer == true && playerScript.isShadow == false)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            playerHealth.health -= 1;
            playerScript.animator.SetTrigger("Hurt");
            camAnim.SetTrigger("Shake");
            StartCoroutine(playerScript.HitTimer());

            if (playerHealth.health <= 0 && playerScript.isDead == false)
            {
                StartCoroutine(playerScript.Die());
                playerScript.isDead = true;
            }
        }
    }

    public IEnumerator MushroomAttack()
    {
        mushroomCanAttack = false;
        anim.SetTrigger("Attack");
        Instantiate(mushroomProjectile, mushroomFirePoint.position, transform.rotation);
        yield return new WaitForSeconds(3);
        mushroomCanAttack = true;
    }

    public IEnumerator SkeletonAttack()
    {
        skeletonCanAttack = false;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(.5f);
        skeletonCanAttack = true;
    }

    public IEnumerator KingSlam()
    {
        kingCanSlam = false;
        anim.SetTrigger("Slam");
        StartCoroutine(FireStar());
        StartCoroutine(SlamStandStill());
        StartCoroutine(KingSlamNoise());
        yield return new WaitForSeconds(10);
        kingCanSlam = true;
    }

    public IEnumerator KingCast()
    {
        kingCanCast = false;
        anim.SetTrigger("Cast");
        StartCoroutine(CastStandStill());
        StartCoroutine(SpawnEnemy());
        StartCoroutine(KingCastNoise());
        yield return new WaitForSeconds(4);
        kingCanCast = true;
    }

    public IEnumerator KingCastCooldown()
    {
        kingCastCooldown = true;
        yield return new WaitForSeconds(3);
        kingCastCooldown = false;
    }
    public IEnumerator KingSlamCooldown()
    {
        kingSlamCooldown = true;
        yield return new WaitForSeconds(2);
        kingSlamCooldown = false;
    }

    public IEnumerator FireStar()
    {
        yield return new WaitForSeconds(.6f);
        Instantiate(bossStar1, bossFirePoint.position, bossFirePoint.rotation);
        Instantiate(bossStar2, bossFirePoint.position, bossFirePoint.rotation);
        Instantiate(bossStar3, bossFirePoint.position, bossFirePoint.rotation);
        Instantiate(bossStar4, bossFirePoint.position, bossFirePoint.rotation);
        Instantiate(bossStar5, bossFirePoint.position, bossFirePoint.rotation);
    }

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        rand = Random.Range(0, enemy.Length);
        Instantiate(enemy[rand], bossSpawnPoint.position, Quaternion.identity);
    }

    public IEnumerator CastStandStill()
    {
        normalSpeed = 0;
        yield return new WaitForSeconds(1.3333333f);
        normalSpeed = 3;
    }

    public IEnumerator SlamStandStill()
    {
        normalSpeed = 0;
        yield return new WaitForSeconds(1.5f);
        normalSpeed = 3;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Spikes"))
        {
            Die();
        }
    }

    public IEnumerator KingSlamNoise()
    {
        FindObjectOfType<AudioManager>().Play("KingGrunt");
        yield return new WaitForSeconds(.6f);
        FindObjectOfType<AudioManager>().Play("KingSlamNoise");
    }

    public IEnumerator KingCastNoise()
    {
        FindObjectOfType<AudioManager>().Play("KingGrunt");
        yield return new WaitForSeconds(1f);
        FindObjectOfType<AudioManager>().Play("KingCastNoise");
    }

    public IEnumerator BonesCrack()
    {
        yield return new WaitForSeconds(.2f);
        FindObjectOfType<AudioManager>().Play("BonesCrack");
    }
}
