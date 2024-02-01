using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawn : MonoBehaviour
{

    public GameObject[] plane = new GameObject[4];
    public float timeInterval;
    public float time;
    Vector2 randomSpawn;
    Quaternion randomRotation;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= timeInterval)
        {
            int randomIndex = Random.Range(0, plane.Length);
            randomSpawn.x = Random.Range(-8, 9);
            randomSpawn.y = Random.Range(-3, 4);
            randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
            Instantiate(plane[randomIndex], randomSpawn, randomRotation);
            time = 0;
        }
    }
}
