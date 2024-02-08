using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Movement : MonoBehaviour
{
    Vector2 target;
    Vector2 direction;
    bool moving;
    bool alive = true;
    public double attackTime;
    public double currentTime;
    public float health = 3;
    public float speed = 2.5f;
    public float stoppingDistance = 0.1f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (alive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = (target - (Vector2)transform.position).normalized;
                moving = true;
            }
            if (moving)
            {
                transform.position += (Vector3)direction * speed * Time.deltaTime;
                if (Vector3.Distance(transform.position, target) < stoppingDistance)
                {
                    animator.SetFloat("Speed", 0);
                    moving = false;
                }
                else
                {
                    animator.SetFloat("Speed", direction.sqrMagnitude);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                animator.SetFloat("Health", health);
                animator.SetBool("Attack", true);
                attackTime = Time.time;
                attackTime += 0.65;
            }
        }
        if (currentTime >= attackTime)
        {
            animator.SetBool("Attack", false);
        }
    }
}
