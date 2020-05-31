using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerEnd : MonoBehaviour
{

    public float speed;
    private float moveInput;

    private Animator animator;
    private Rigidbody2D rb;

    public GameObject playerText1;
    public GameObject playerText2;
    public GameObject playerText3;

    public GameObject kingText1;


    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        StartCoroutine(WalkForward());
        StartCoroutine(PlayerText1());

        FindObjectOfType<AudioManager>().Play("IntroMusic");
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {

            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
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
        yield return new WaitForSeconds(4);
        playerText3.SetActive(true);
        StartCoroutine(PanelFadeOut());
    }

    public IEnumerator KingText1()
    {
        yield return new WaitForSeconds(4);
        kingText1.SetActive(true);
        StartCoroutine(PlayerText3());
    }

    public IEnumerator PanelFadeOut()
    {
        yield return new WaitForSeconds(4);
        pauseMenu.EndCreditsNow();
    }
}
