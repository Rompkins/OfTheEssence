using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerIntro : MonoBehaviour
{

    public float speed;
    private float moveInput;

    private Animator animator;
    private Rigidbody2D rb;

    public TextMeshProUGUI countdown;
    public GameObject magicBar;
    public GameObject hearts;

    public GameObject playerText1;
    public GameObject playerText2;
    public GameObject playerText3;
    public GameObject playerText4;

    public GameObject kingText1;
    public GameObject kingText2;
    public GameObject kingText3;
    public GameObject kingText4;

    public Animator kingAnim;

    public GameObject heart9;
    public GameObject heart8;
    public GameObject heart7;
    public GameObject heart6;
    public GameObject heart5;
    public GameObject heart4;
    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;

    public Animator oldTimer;
    public GameObject newTimer;
    public TextMeshProUGUI newCountdown;
    public bool newTimerBool;
    public float timer = 10;

    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        StartCoroutine(WalkForward());
        StartCoroutine(PlayerText1());

        kingAnim.SetTrigger("IsIdle");
        FindObjectOfType<AudioManager>().Play("IntroMusic");
    }

    // Update is called once per frame
    void Update()
    {
        if (newTimerBool == true)
        {
            timer -= Time.deltaTime;
            newCountdown.text = Mathf.Round(timer).ToString();

            if (timer < 10.5)
            {
                newCountdown.color = new Color32(255, 0, 0, 255);
            }

            if (timer > 10.5)
            {
                newCountdown.color = new Color32(255, 255, 255, 255);
            }

            if (timer <= 0.5)
            {
                timer = 0;
            }
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {

            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pauseMenu.StartGameNow();
        }
    }

    public IEnumerator WalkForward()
    {
        moveInput = 1;
        yield return new WaitForSeconds(9);
        moveInput = 0;
    }


    public IEnumerator PlayerText1()
    {
        yield return new WaitForSeconds(1);
        playerText1.SetActive(true);
        StartCoroutine(PlayerText2());
    }
    public IEnumerator PlayerText2()
    {
        yield return new WaitForSeconds(8);
        playerText2.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("IntroMusic");
        FindObjectOfType<AudioManager>().Play("KingMusic");
        StartCoroutine(KingText1());
    }

    public IEnumerator PlayerText3()
    {
        yield return new WaitForSeconds(5);
        playerText3.SetActive(true);
        StartCoroutine(KingText3());
    }

    public IEnumerator PlayerText4()
    {
        yield return new WaitForSeconds(7);
        playerText4.SetActive(true);
        StartCoroutine(KingText4());
    }

    public IEnumerator KingText1()
    {
        yield return new WaitForSeconds(5);
        kingText1.SetActive(true);
        StartCoroutine(KingText2());
    }

    public IEnumerator KingText2()
    {
        yield return new WaitForSeconds(4);
        kingText2.SetActive(true);
        StartCoroutine(PlayerText3());
    }

    public IEnumerator KingText3()
    {
        yield return new WaitForSeconds(5);
        kingText3.SetActive(true);
        StartCoroutine(KingCast());
        StartCoroutine(PlayerDie());
        StartCoroutine(PlayerText4());
        StartCoroutine(KillHearts());
        StartCoroutine(ClockChange());
    }

    public IEnumerator KingText4()
    {
        yield return new WaitForSeconds(5);
        kingText4.SetActive(true);
    }

    public IEnumerator KingCast()
    {
        yield return new WaitForSeconds(4.5f);
        kingAnim.SetTrigger("IntroCast");
        StartCoroutine(KingCastNoise());
    }

    public IEnumerator KingCastNoise()
    {
        FindObjectOfType<AudioManager>().Play("KingGrunt");
        yield return new WaitForSeconds(1f);
        FindObjectOfType<AudioManager>().Play("KingCastNoise");
    }
    public IEnumerator PlayerDie()
    {
        yield return new WaitForSeconds(6);
        animator.SetBool("IsDead", true);
    }

    public IEnumerator KillHearts()
    {
        yield return new WaitForSeconds(5);
        Destroy(heart9, 0.5f);
        Destroy(heart8, 1);
        Destroy(heart7, 1.5f);
        Destroy(heart6, 2);
        Destroy(heart5, 2.5f);
        Destroy(heart4, 3);
        Destroy(heart3, 3.5f);
        Destroy(heart2, 4);
        Destroy(heart1, 4.5f);
        Destroy(magicBar, 5);
        oldTimer.SetTrigger("Fade");
    }

    public IEnumerator ClockChange()
    {
        yield return new WaitForSeconds(6);
        newTimer.SetActive(true);
        newTimerBool = true;
        StartCoroutine(PanelFadeOut());
    }

    public IEnumerator PanelFadeOut()
    {
        yield return new WaitForSeconds(10);
        pauseMenu.StartGameNow();
    }
}
