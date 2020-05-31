using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenuItems : MonoBehaviour
{
    public GameObject magicSpell;
    public PlayerAttack magicSpellBool;
    public GameObject magicSpellText;
    public GameObject lockItem1;

    public GameObject doubleJump;
    public BTPMovement doubleJumpValue;
    public GameObject doubleJumpText;
    public GameObject lockItem2;

    public GameObject shadowMode;
    public BTPMovement canShadowMode;
    public GameObject shadowModeText;
    public GameObject lockItem3;

    public TextMeshProUGUI heartNumberText;
    public Health health;

    public TextMeshProUGUI hourglassNumberText;
    public Countdown hourglassNumber;

    // Start is called before the first frame update
    void Start()
    {
        magicSpell.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        magicSpellText.SetActive(false);
        lockItem1.SetActive(true);

        doubleJump.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        doubleJumpText.SetActive(false);
        lockItem2.SetActive(true);

        shadowMode.GetComponent<Image>().color = new Color(.2f, .2f, .2f, 0.2f);
        shadowModeText.SetActive(false);
        lockItem3.SetActive(true);

        heartNumberText.text = health.numOfHearts - 3 + "/7";
        hourglassNumberText.text = hourglassNumber.hourglassNumber + "/10";
    }

    // Update is called once per frame
    void Update()
    {
        if (magicSpellBool.canMagic == true)
        {
            magicSpell.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            magicSpellText.SetActive(true);
            lockItem1.SetActive(false);
        }

        if (doubleJumpValue.extraJumpsValue == 1)
        {
            doubleJump.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            doubleJumpText.SetActive(true);
            lockItem2.SetActive(false);
        }

        if (canShadowMode.canShadowMode == true)
        {
            shadowMode.GetComponent<Image>().color = new Color(.2f, .2f, .2f, 1f);
            shadowModeText.SetActive(true);
            lockItem3.SetActive(false);
        }

        heartNumberText.text = health.numOfHearts + "/10";
        hourglassNumberText.text = hourglassNumber.hourglassNumber + "/10";
    }
}
