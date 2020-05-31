using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicPotion : MonoBehaviour
{
    private MagicBar magicBar;
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        magicBar = GameObject.FindGameObjectWithTag("Magic Bar").GetComponent<MagicBar>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("PickupItem");
            magicBar.GetComponent<Slider>().value += 30;
            playerAttack.currentMagic += 30;
            Destroy(gameObject);
        }
    }
}
