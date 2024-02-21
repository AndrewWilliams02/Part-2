using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    float currentTime;
    float timer = 3;
    Vector2 randomSpawn;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.deltaTime; //Set starting time
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime; //Calculate time since last enemy spawned

        //Spawns new enemy if timer is finished
        if (currentTime >= timer)
        {
            randomSpawn.x = Random.Range(-8, 8);
            randomSpawn.y = Random.Range(-4, 0);
            Instantiate(enemy, randomSpawn, transform.rotation);
            currentTime = 0;
        }
    }
}
