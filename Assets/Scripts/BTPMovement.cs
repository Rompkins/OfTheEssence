using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTPMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    public bool isGrounded;

    private bool facingRight = true;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    public int extraJumpsValue;

    public GameObject doubleJumpText1;
    public GameObject doubleJumpText2;

    public GameObject doubleJumpCollect;
    public GameObject shadowModeCollect;

    public Animator animator;

    public Animator camAnim;
    public AudioSource audioSource;

    public Health health;

    public GameObject explosion;

    private SpriteRenderer ren;

    public Countdown countdown;
    public bool isDead = false;
    public bool hitTimer = true;

    public bool canShadowMode = false;
    public bool isShadow = false;
    public PlayerAttack playerAttack;

    public GameObject shadowModeText1;
    public GameObject shadowModeText2;

    public GameObject hourglassCollect;
    public GameObject collectEffect;

    public GameObject doubleJumpPowerup;
    public int doubleJumpInt;

    public GameObject shadowModePowerup;
    public int shadowModeInt;

    public GameObject bossHealth;

    public GameObject tutorialText;
    public int tutorialTextInt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
        ren = GetComponent<SpriteRenderer>();

        doubleJumpInt = PlayerPrefs.GetInt("DoubleJump", 0);
        shadowModeInt = PlayerPrefs.GetInt("ShadowMode", 0);
        tutorialTextInt = PlayerPrefs.GetInt("TutorialText", 0);

        if(tutorialTextInt == 0)
        {
            StartCoroutine(TutorialText());
        }

        if (doubleJumpInt == 0)
        {
            doubleJumpPowerup.SetActive(true);
            extraJumpsValue = 0;
        }
        else
        {
            doubleJumpPowerup.SetActive(false);
            extraJumpsValue = 1;
        }

        if (shadowModeInt == 0)
        {
            shadowModePowerup.SetActive(true);
            canShadowMode = false;
        }
        else
        {
            shadowModePowerup.SetActive(false);
            canShadowMode = true;
        }

        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "GameScene")
        {
            animator.SetTrigger("HasRisen");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            flip();
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            doubleJumpInt = 0;
            shadowModeInt = 0;
        }

        if (rb.position.y < -40)
        {
            bossHealth.SetActive(true);
        }

        if (Input.GetKey(KeyCode.S) && playerAttack.canMagic == true && canShadowMode == true)
        {
            ren.color = new Color(.2f, .2f, .2f, 1);
            isShadow = true;
            Physics2D.IgnoreLayerCollision(9, 14, true);
            Physics2D.IgnoreLayerCollision(9, 16, true);
            Physics2D.IgnoreLayerCollision(9, 15, true);


        }
        else
        {
            ren.color = new Color(1, 1, 1, 1);
            isShadow = false;
            Physics2D.IgnoreLayerCollision(9, 14, false);
            Physics2D.IgnoreLayerCollision(9, 16, false);
            Physics2D.IgnoreLayerCollision(9, 15, false);

        }

        if (moveInput == 0)
        {

            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

        if ((Input.GetKeyDown(KeyCode.W) && extraJumps > 0) || (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0))
        {
            
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            animator.SetTrigger("Jump");
        }

        else if((Input.GetKeyDown(KeyCode.W) && isGrounded == true && extraJumps == 0) || (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true && extraJumps == 0))
        {
            
            rb.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("Jump");
        }

        if (countdown.death == true && isDead == false)
        {
            StartCoroutine(Die());
            isDead = true;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Spikes"))
        {
            health.health = 0;
            camAnim.SetTrigger("Shake");
            StartCoroutine("Die");
        }

        if (collision.collider.CompareTag("Shroom") && hitTimer == false)
        {
            Destroy(collision.collider.gameObject);
        }

            if (collision.collider.CompareTag("Shroom") && hitTimer == true && isShadow == false)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            Destroy(collision.collider.gameObject);
            health.health -= 1;
            animator.SetTrigger("Hurt");
            camAnim.SetTrigger("Shake");
            StartCoroutine(HitTimer());

            if (health.health <= 0 && isDead == false)
            {
                StartCoroutine(Die());
                isDead = true;
            }
        }

        if (collision.collider.CompareTag("BossStar") && hitTimer == false)
        {
            Destroy(collision.collider.gameObject);
        }

            if (collision.collider.CompareTag("BossStar") && hitTimer == true && isShadow == false)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            Destroy(collision.collider.gameObject);
            health.health -= 2;
            animator.SetTrigger("Hurt");
            camAnim.SetTrigger("Shake");
            StartCoroutine(HitTimer());

            if (health.health <= 0 && isDead == false)
            {
                StartCoroutine(Die());
                isDead = true;
            }
        }
    }

    public IEnumerator Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        ren.enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    public IEnumerator HitTimer()
    {
        hitTimer = false;
        //add invincible flash animation
        yield return new WaitForSeconds(1);
        hitTimer = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("DoubleJump"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PowerupNoise");
            extraJumpsValue = 1;
            doubleJumpInt = 1;
            PlayerPrefs.SetInt("DoubleJump", doubleJumpInt);
            StartCoroutine(DoubleJumpTexts());
            Instantiate(doubleJumpCollect, transform.position, transform.rotation);

        }

        if (collision.CompareTag("ShadowModePower"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PowerupNoise");
            canShadowMode = true;
            shadowModeInt = 1;
            PlayerPrefs.SetInt("ShadowMode", shadowModeInt);
            StartCoroutine(ShadowModeTexts());
            Instantiate(shadowModeCollect, transform.position, transform.rotation);
        }

        if (collision.CompareTag("Hourglass1"))
        {
            Destroy(collision.gameObject);
            countdown.IncreaseTime();
            countdown.hourglassNumber+=1;
            countdown.hourglass1 = 1;
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("Hourglass2"))
        {
            countdown.IncreaseTime();
            countdown.hourglassNumber += 1;
            countdown.hourglass2 = 1;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("Hourglass3"))
        {
            Destroy(collision.gameObject);
            countdown.IncreaseTime();
            countdown.hourglassNumber += 1;
            countdown.hourglass3 = 1;
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("Hourglass4"))
        {
            countdown.IncreaseTime();
            countdown.hourglassNumber += 1;
            countdown.hourglass4 = 1;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("Hourglass5"))
        {
            countdown.IncreaseTime();
            countdown.hourglassNumber += 1;
            countdown.hourglass5 = 1;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("Hourglass6"))
        {
            countdown.IncreaseTime();
            countdown.hourglassNumber += 1;
            countdown.hourglass6 = 1;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("Hourglass7"))
        {
            countdown.IncreaseTime();
            countdown.hourglassNumber += 1;
            countdown.hourglass7 = 1;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("Hourglass8"))
        {
            countdown.IncreaseTime();
            countdown.hourglassNumber += 1;
            countdown.hourglass8 = 1;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("Hourglass9"))
        {
            countdown.IncreaseTime();
            countdown.hourglassNumber += 1;
            countdown.hourglass9 = 1;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("Hourglass10"))
        {
            countdown.IncreaseTime();
            countdown.hourglassNumber += 1;
            countdown.hourglass10 = 1;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            PlayerPrefs.SetInt("HourglassNumber", countdown.hourglassNumber);
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }

        if (collision.CompareTag("HeartContainer1"))
        {
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            health.IncreaseHearts();
            health.heartNumber1 = 1;
            Destroy(collision.gameObject);
            Instantiate(collectEffect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("HeartContainer2"))
        {
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            health.IncreaseHearts();
            health.heartNumber2 = 1;
            Destroy(collision.gameObject);
            Instantiate(collectEffect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("HeartContainer3"))
        {
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            health.IncreaseHearts();
            health.heartNumber3 = 1;
            Destroy(collision.gameObject);
            Instantiate(collectEffect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("HeartContainer4"))
        {
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            health.IncreaseHearts();
            health.heartNumber4 = 1;
            Destroy(collision.gameObject);
            Instantiate(collectEffect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("HeartContainer5"))
        {
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            health.IncreaseHearts();
            health.heartNumber5 = 1;
            Destroy(collision.gameObject);
            Instantiate(collectEffect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("HeartContainer6"))
        {
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            health.IncreaseHearts();
            health.heartNumber6 = 1;
            Destroy(collision.gameObject);
            Instantiate(collectEffect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("HeartContainer7"))
        {
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            health.IncreaseHearts();
            health.heartNumber7 = 1;
            Destroy(collision.gameObject);
            Instantiate(collectEffect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("HeartContainer8"))
        {
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            health.IncreaseHearts();
            health.heartNumber8 = 1;
            Destroy(collision.gameObject);
            Instantiate(collectEffect, transform.position, transform.rotation);
        }
        if (collision.CompareTag("HeartContainer9"))
        {
            FindObjectOfType<AudioManager>().Play("PickupPerm");
            health.IncreaseHearts();
            health.heartNumber9 = 1;
            Destroy(collision.gameObject);
            Instantiate(collectEffect, transform.position, transform.rotation);
        }
    }

    public IEnumerator DoubleJumpTexts()
    {
        doubleJumpText1.SetActive(true);
        doubleJumpText2.SetActive(true);
        yield return new WaitForSeconds(7);
        doubleJumpText1.SetActive(false);
        doubleJumpText2.SetActive(false);
    }

    public IEnumerator ShadowModeTexts()
    {
        shadowModeText1.SetActive(true);
        shadowModeText2.SetActive(true);
        yield return new WaitForSeconds(7);
        shadowModeText1.SetActive(false);
        shadowModeText2.SetActive(false);
    }

    public IEnumerator TutorialText()
    {
        tutorialText.SetActive(true);
        yield return new WaitForSeconds(10);
        tutorialTextInt = 1;
        PlayerPrefs.SetInt("TutorialText", 1);
    }
}
