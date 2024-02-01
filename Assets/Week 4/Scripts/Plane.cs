using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    public float speed;
    public AnimationCurve landing;
    public float landingTimer;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    Vector2 currentPosition;
    Color planeColor;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        speed = Random.Range(1, 4);
        planeColor = Color.white;
        spriteRenderer.color = planeColor;
        planeLand = false;
    }

    void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidBody.rotation = -angle;
        }
        rigidBody.MovePosition(rigidBody.position + (Vector2)transform.up * speed * Time.deltaTime);
        spriteRenderer.color = planeColor;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)
        { 
            landingTimer += 0.005f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, currentPosition);
        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
        spriteRenderer.color = planeColor;
    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        spriteRenderer.color = planeColor;
    }

    void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
        spriteRenderer.color = planeColor;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
            planeColor = Color.red;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
            planeColor = Color.red;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        planeColor = Color.white;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        Destroy(this);
    }
}
