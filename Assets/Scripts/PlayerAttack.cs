using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBetweenAttack;

    private float timeBtwCastAttack;
    public float startTimeBetweenCastAttack;

    private Rigidbody2D rb;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;
    public Animator camAnim;
    public Animator playerAnim;

    public GameObject magicSpell;
    public Transform spellPoint;

    public MagicBar magicBar;
    public int maxMagic;
    public int currentMagic;
    public int spellAmount;

    public bool canMagic = false;
    public GameObject magicShow;

    public GameObject magicSpellText1;
    public GameObject magicSpellText2;

    public GameObject magicPowerCollect;

    public GameObject magicPowerup;
    public int magicInt;

    // Start is called before the first frame update
    void Start()
    {
        currentMagic = maxMagic;
        magicBar.SetMaxMagic(maxMagic);
        rb = GetComponent<Rigidbody2D>();
        magicInt = PlayerPrefs.GetInt("Magic", 0);


        if (magicInt == 0)
        {
            magicShow.SetActive(false);
            magicPowerup.SetActive(true);
            canMagic = false;
        }
        else
        {
            magicShow.SetActive(true);
            magicPowerup.SetActive(false);
            canMagic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            magicInt = 0;
        }

       

        if(timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<AudioManager>().Play("SwordSlash1");
                playerAnim.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                foreach(Collider2D enemy in enemiesToDamage)
                {
                    FindObjectOfType<AudioManager>().Play("HitNoise");
                    enemy.GetComponent<Enemy>().TakeDamage(damage);
                    camAnim.SetTrigger("Shake");

                }

                timeBtwAttack = startTimeBetweenAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if (timeBtwCastAttack <= 0 && currentMagic > 0 && canMagic == true)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                currentMagic -= spellAmount;
                magicBar.SetMagic(currentMagic);
                playerAnim.SetTrigger("CastAttack");
                FindObjectOfType<AudioManager>().Play("SpellNoise");
                Instantiate(magicSpell, spellPoint.position, transform.rotation);
                timeBtwCastAttack = startTimeBetweenCastAttack;
            }
        }
        else
        {
            timeBtwCastAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagicPower"))
        {
            canMagic = true;
            FindObjectOfType<AudioManager>().Play("PowerupNoise");
            magicShow.SetActive(true);
            magicInt = 1;
            PlayerPrefs.SetInt("Magic", magicInt);
            Destroy(collision.gameObject);
            StartCoroutine(MagicSpellTexts());
            Instantiate(magicPowerCollect, transform.position, transform.rotation);
        }
    }

    public IEnumerator MagicSpellTexts()
    {
        magicSpellText1.SetActive(true);
        magicSpellText2.SetActive(true);
        yield return new WaitForSeconds(10);
        magicSpellText1.SetActive(false);
        magicSpellText2.SetActive(false);
    }
}
