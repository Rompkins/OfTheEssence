using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public Animator panelAnim;
    public GameObject coverPanel;

    public bool endGame = false;
    public bool isEnding = false;


    private void Start()
    {
        StartCoroutine(KillPanel());
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "GameScene")
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        if(endGame == true)
        {
            StartCoroutine(EndGame());
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void StartGameNow()
    {
        StartCoroutine(StartGame());
    }

    public void StartIntroStory()
    {
        StartCoroutine(IntroStory());
    }

    public void EndCreditsNow()
    {
        StartCoroutine(EndCredits());
    }

    public void QuitNow()
    {
        StartCoroutine(Quit());
    }

    public void QuitGamePause()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void RestartGamePause()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public IEnumerator Quit()
    {
        coverPanel.SetActive(true);
        panelAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public IEnumerator IntroStory()
    {
        coverPanel.SetActive(true);
        panelAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public IEnumerator StartGame()
    {
        coverPanel.SetActive(true);
        panelAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public IEnumerator KillPanel()
    {
        yield return new WaitForSeconds(1);
        coverPanel.SetActive(false);
    }

    public IEnumerator EndGame()
    {
        if (isEnding == false)
        {
            isEnding = true;
            FindObjectOfType<AudioManager>().Stop("BackgroundMusic");
            FindObjectOfType<AudioManager>().Play("KillBossSong");
            yield return new WaitForSeconds(5);
            StartCoroutine(EndStory());
        }
    }

    public IEnumerator EndStory()
    {
        coverPanel.SetActive(true);
        panelAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }

    public IEnumerator EndCredits()
    {
        coverPanel.SetActive(true);
        panelAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(4);
    }
}
