using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneTransitions : MonoBehaviour
{
    public int player;
    public GameObject chicken;
    public GameObject cham;
    public GameObject bunny;

    public Button chickenButton;
    public Button chamButton;
    public Button bunnyButton;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI jumpText;
    public TextMeshProUGUI doubleJumpText;
    public TextMeshProUGUI gravityText;

    public bool restart = false;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerPrefs.GetInt("PlayerInt",1);

        if(player == 1)
        {
            chicken.SetActive(true);
        }
        else if (player == 2)
        {
            cham.SetActive(true);
        }
        else if (player == 3)
        {
            bunny.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = PlayerPrefs.GetInt("PlayerInt",1);

        if (restart) 
        {
            SceneManager.LoadScene(0);
            restart = false;
        }

        if(player == 1)
        {
            chickenButton.interactable = false;
            chamButton.interactable = true;
            bunnyButton.interactable = true;
            speedText.text = "Speed: 5";
            jumpText.text = "Jump Height: 8";
            doubleJumpText.text = "Double Jump: ON";
            gravityText.text = "Antigravity: OFF";
        }
        if (player == 2)
        {
            chamButton.interactable = false;
            chickenButton.interactable = true;
            bunnyButton.interactable = true;
            speedText.text = "Speed: 5";
            jumpText.text = "Jump Height: 8";
            doubleJumpText.text = "Double Jump: OFF";
            gravityText.text = "Antigravity: ON";
        }
        if (player == 3)
        {
            bunnyButton.interactable = false;
            chamButton.interactable = true;
            chickenButton.interactable = true;
            speedText.text = "Speed: 6";
            jumpText.text = "Jump Height: 14";
            doubleJumpText.text = "Double Jump: OFF";
            gravityText.text = "Antigravity: OFF";
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            RestartLevel();
        }
    }

    public IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
        //gameObject.SetActive(true);
    }

    public void PickChicken()
    {
        PlayerPrefs.SetInt("PlayerInt", 1);
    }
    public void PickCham()
    {
        PlayerPrefs.SetInt("PlayerInt", 2);
    }
    public void PickBunny()
    {
        PlayerPrefs.SetInt("PlayerInt", 3);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
