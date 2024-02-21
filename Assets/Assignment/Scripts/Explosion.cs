using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst.CompilerServices;

public class Explosion : MonoBehaviour
{
    bool hit = false;
    Animator animator;
    float animTime = 1.16f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Runs the "MoveObject" method if bullet hasnt hit anything
        if (!hit)
        {
            SendMessage("MoveObject");
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        // If bullet his enemy sets hit to true and runs explosion animation before destroying
        hit = true;
        animator.SetBool("Hit", hit);
        Destroy(gameObject, animTime);
    }
}
