using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject heartContainer1;
    public GameObject heartContainer2;
    public GameObject heartContainer3;
    public GameObject heartContainer4;
    public GameObject heartContainer5;
    public GameObject heartContainer6;
    public GameObject heartContainer7;
    public GameObject heartContainer8;
    public GameObject heartContainer9;

    public int heartNumber1;
    public int heartNumber2;
    public int heartNumber3;
    public int heartNumber4;
    public int heartNumber5;
    public int heartNumber6;
    public int heartNumber7;
    public int heartNumber8;
    public int heartNumber9;



    void Start()
    {
        health = PlayerPrefs.GetInt("Health", 1);
        numOfHearts = PlayerPrefs.GetInt("NumOfHearts", 1);

        heartNumber1 = PlayerPrefs.GetInt("Heart1", 0);
        heartNumber2 = PlayerPrefs.GetInt("Heart2", 0);
        heartNumber3 = PlayerPrefs.GetInt("Heart3", 0);
        heartNumber4 = PlayerPrefs.GetInt("Heart4", 0);
        heartNumber5 = PlayerPrefs.GetInt("Heart5", 0);
        heartNumber6 = PlayerPrefs.GetInt("Heart6", 0);
        heartNumber7 = PlayerPrefs.GetInt("Heart7", 0);
        heartNumber8 = PlayerPrefs.GetInt("Heart8", 0);
        heartNumber9 = PlayerPrefs.GetInt("Heart9", 0);

        if (heartNumber1 == 0)
        {
            heartContainer1.SetActive(true);
        }
        else
        {
            heartContainer1.SetActive(false);
        }

        if (heartNumber2 == 0)
        {
            heartContainer2.SetActive(true);
        }
        else
        {
            heartContainer2.SetActive(false);
        }

        if (heartNumber3 == 0)
        {
            heartContainer3.SetActive(true);
        }
        else
        {
            heartContainer3.SetActive(false);
        }

        if (heartNumber4 == 0)
        {
            heartContainer4.SetActive(true);
        }
        else
        {
            heartContainer4.SetActive(false);
        }

        if (heartNumber5 == 0)
        {
            heartContainer5.SetActive(true);
        }
        else
        {
            heartContainer5.SetActive(false);
        }

        if (heartNumber6 == 0)
        {
            heartContainer6.SetActive(true);
        }
        else
        {
            heartContainer6.SetActive(false);
        }

        if (heartNumber7 == 0)
        {
            heartContainer7.SetActive(true);
        }
        else
        {
            heartContainer7.SetActive(false);
        }

        if (heartNumber8 == 0)
        {
            heartContainer8.SetActive(true);
        }
        else
        {
            heartContainer8.SetActive(false);
        }

        if (heartNumber9 == 0)
        {
            heartContainer9.SetActive(true);
        }
        else
        {
            heartContainer9.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            heartNumber1 = 0;
            heartNumber2 = 0;
            heartNumber3 = 0;
            heartNumber4 = 0;
            heartNumber5 = 0;
            heartNumber6 = 0;
            heartNumber7 = 0;
            heartNumber8 = 0;
            heartNumber9 = 0;

        }

        if (heartNumber1 == 1)
        {
            PlayerPrefs.SetInt("Heart1", 1);
        }
        if (heartNumber2 == 1)
        {
            PlayerPrefs.SetInt("Heart2", 1);
        }
        if (heartNumber3 == 1)
        {
            PlayerPrefs.SetInt("Heart3", 1);
        }
        if (heartNumber4 == 1)
        {
            PlayerPrefs.SetInt("Heart4", 1);
        }
        if (heartNumber5 == 1)
        {
            PlayerPrefs.SetInt("Heart5", 1);
        }
        if (heartNumber6 == 1)
        {
            PlayerPrefs.SetInt("Heart6", 1);
        }
        if (heartNumber7 == 1)
        {
            PlayerPrefs.SetInt("Heart7", 1);
        }
        if (heartNumber8 == 1)
        {
            PlayerPrefs.SetInt("Heart8", 1);
        }
        if (heartNumber9 == 1)
        {
            PlayerPrefs.SetInt("Heart9", 1);
        }

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;

            }
        }

    }
    public void IncreaseHearts()
    {
        numOfHearts++;
        health = numOfHearts;
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("NumOfHearts", numOfHearts);
    }

    public void TakeDamage()
    {
        health--;
    }
}
