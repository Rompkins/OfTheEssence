using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : MonoBehaviour
{

    public Countdown countdown;
    public int hourglassNumber;
    public GameObject hourglassCollect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            countdown.IncreaseTime();
            Destroy(gameObject);
            countdown.hourglassNumber++;
            Instantiate(hourglassCollect, transform.position, transform.rotation);
        }
    }
}
