using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timeAlive;
    float timer = 5;
    float exitTime;
    bool exiting = false;
    public AnimationCurve exitShrink;
    float interpolation;
    GameObject scoreTracker;
    // Start is called before the first frame update
    void Start()
    {
        timeAlive = Time.deltaTime; // Set time enemy spawned at
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime; // Calculate time since enemy spawned

        // If enemy has been alive for 5 seconds start to shrik enemy and deystroy once size is too small
        if (timeAlive >= timer)
        {
            exitTime = (0.25f * Time.deltaTime);
            interpolation = exitShrink.Evaluate(exitTime);
            if (transform.localScale.x < 0.1f && transform.localScale.y < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If bullet hits enemy deystroy
        Destroy(gameObject);
    }
}
