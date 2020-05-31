using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public int rand;
    public Transform target;
    public float distanceNumX;
    public float distanceNumY;
    public bool spawned =  false;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, enemy.Length);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceNumX = transform.position.x - target.transform.position.x;
        distanceNumY = transform.position.y - target.transform.position.y;

        if (distanceNumX < 20 && distanceNumX > -20 && distanceNumY < 10 && distanceNumY > -10 && spawned == false)
        {
            Instantiate(enemy[rand], transform.position, transform.rotation);
            spawned = true;
        }
    }
}
