using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI beetleText;


    public int score;

    public int beetle1Int;
    public GameObject beetle1;
    public int beetle2Int;
    public GameObject beetle2;
    public int beetle3Int;
    public GameObject beetle3;
    public int beetle4Int;
    public GameObject beetle4;
    public int beetle5Int;
    public GameObject beetle5;
    public int beetle6Int;
    public GameObject beetle6;
    public int beetle7Int;
    public GameObject beetle7;
    public int beetle8Int;
    public GameObject beetle8;
    public int beetle9Int;
    public GameObject beetle9;
    public int beetle10Int;
    public GameObject beetle10;
    public int beetle11Int;
    public GameObject beetle11;
    public int beetle12Int;
    public GameObject beetle12;
    public int beetle13Int;
    public GameObject beetle13;
    public int beetle14Int;
    public GameObject beetle14;
    public int beetle15Int;
    public GameObject beetle15;

    public GameObject beetleA;
    public int beetleAInt;
    public GameObject beetleB;
    public int beetleBInt;
    public GameObject beetleC;
    public int beetleCInt;
    public GameObject beetleD;
    public int beetleDInt;
    public GameObject beetleE;
    public int beetleEInt;
    public GameObject beetleF;
    public int beetleFInt;
    public GameObject beetleG;
    public int beetleGInt;
    public GameObject beetleH;
    public int beetleHInt;
    public GameObject beetleI;
    public int beetleIInt;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);

        beetle1Int = PlayerPrefs.GetInt("Beetle1", 1);

        beetleAInt = PlayerPrefs.GetInt("BeetleA", 1);
        beetleBInt = PlayerPrefs.GetInt("BeetleB", 1);
        beetleCInt = PlayerPrefs.GetInt("BeetleC", 1);
        beetleDInt = PlayerPrefs.GetInt("BeetleD", 1);
        beetleEInt = PlayerPrefs.GetInt("BeetleE", 1);
        beetleFInt = PlayerPrefs.GetInt("BeetleF", 1);
        beetleGInt = PlayerPrefs.GetInt("BeetleG", 1);
        beetleHInt = PlayerPrefs.GetInt("BeetleH", 1);
        beetleIInt = PlayerPrefs.GetInt("BeetleI", 1);

        beetle1Int = PlayerPrefs.GetInt("Beetle1", 1);
        beetle2Int = PlayerPrefs.GetInt("Beetle2", 1);
        beetle3Int = PlayerPrefs.GetInt("Beetle3", 1);
        beetle4Int = PlayerPrefs.GetInt("Beetle4", 1);
        beetle5Int = PlayerPrefs.GetInt("Beetle5", 1);
        beetle6Int = PlayerPrefs.GetInt("Beetle6", 1);
        beetle7Int = PlayerPrefs.GetInt("Beetle7", 1);
        beetle8Int = PlayerPrefs.GetInt("Beetle8", 1);
        beetle9Int = PlayerPrefs.GetInt("Beetle9", 1);
        beetle10Int = PlayerPrefs.GetInt("Beetle10", 1);
        beetle11Int = PlayerPrefs.GetInt("Beetle11", 1);
        beetle12Int = PlayerPrefs.GetInt("Beetle12", 1);
        beetle13Int = PlayerPrefs.GetInt("Beetle13", 1);
        beetle14Int = PlayerPrefs.GetInt("Beetle14", 1);
        beetle15Int = PlayerPrefs.GetInt("Beetle15", 1);


        if (beetle1Int == 1)
        {
            beetle1.SetActive(true);
        }
        else
        {
            beetle1.SetActive(false);
        }

        if (beetle2Int == 1)
        {
            beetle2.SetActive(true);
        }
        else
        {
            beetle2.SetActive(false);
        }

        if (beetle3Int == 1)
        {
            beetle3.SetActive(true);
        }
        else
        {
            beetle3.SetActive(false);
        }

        if (beetle4Int == 1)
        {
            beetle4.SetActive(true);
        }
        else
        {
            beetle4.SetActive(false);
        }

        if (beetle5Int == 1)
        {
            beetle5.SetActive(true);
        }
        else
        {
            beetle5.SetActive(false);
        }

        if (beetle6Int == 1)
        {
            beetle6.SetActive(true);
        }
        else
        {
            beetle6.SetActive(false);
        }

        if (beetle7Int == 1)
        {
            beetle7.SetActive(true);
        }
        else
        {
            beetle7.SetActive(false);
        }

        if (beetle8Int == 1)
        {
            beetle8.SetActive(true);
        }
        else
        {
            beetle8.SetActive(false);
        }

        if (beetle9Int == 1)
        {
            beetle9.SetActive(true);
        }
        else
        {
            beetle9.SetActive(false);
        }

        if (beetle10Int == 1)
        {
            beetle10.SetActive(true);
        }
        else
        {
            beetle10.SetActive(false);
        }

        if (beetle11Int == 1)
        {
            beetle11.SetActive(true);
        }
        else
        {
            beetle11.SetActive(false);
        }

        if (beetle12Int == 1)
        {
            beetle12.SetActive(true);
        }
        else
        {
            beetle12.SetActive(false);
        }

        if (beetle13Int == 1)
        {
            beetle13.SetActive(true);
        }
        else
        {
            beetle13.SetActive(false);
        }

        if (beetle14Int == 1)
        {
            beetle14.SetActive(true);
        }
        else
        {
            beetle14.SetActive(false);
        }

        if (beetle15Int == 1)
        {
            beetle15.SetActive(true);
        }
        else
        {
            beetle15.SetActive(false);
        }


        if (beetleAInt == 1)
        {
            beetleA.SetActive(true);
        }
        else
        {
            beetleA.SetActive(false);
        }

        if (beetleBInt == 1)
        {
            beetleB.SetActive(true);
        }
        else
        {
            beetleB.SetActive(false);
        }

        if (beetleCInt == 1)
        {
            beetleC.SetActive(true);
        }
        else
        {
            beetleC.SetActive(false);
        }

        if (beetleDInt == 1)
        {
            beetleD.SetActive(true);
        }
        else
        {
            beetleD.SetActive(false);
        }

        if (beetleEInt == 1)
        {
            beetleE.SetActive(true);
        }
        else
        {
            beetleE.SetActive(false);
        }

        if (beetleFInt == 1)
        {
            beetleF.SetActive(true);
        }
        else
        {
            beetleF.SetActive(false);
        }

        if (beetleGInt == 1)
        {
            beetleG.SetActive(true);
        }
        else
        {
            beetleG.SetActive(false);
        }

        if (beetleHInt == 1)
        {
            beetleH.SetActive(true);
        }
        else
        {
            beetleH.SetActive(false);
        }

        if (beetleIInt == 1)
        {
            beetleI.SetActive(true);
        }
        else
        {
            beetleI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        beetleText.text = score.ToString() + "/25";


        //start entering more TMPro variables here next!!!

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }




    }
   
}
