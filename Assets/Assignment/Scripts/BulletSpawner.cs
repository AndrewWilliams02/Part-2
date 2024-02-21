using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    float mouseAngle;
    public Vector2 mouseDir;
    public Vector2 mousePos;
    public Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position; // Get position of spawner
    }

    // Update is called once per frame
    void Update()
    {
        // If left mouse button clicked spawn bullet moving in the direction the mouse was clicked
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseDir = (mousePos - (Vector2)transform.position).normalized;
            GameObject newBullet = Instantiate(bullet, spawnPos, Quaternion.identity);
            newBullet.GetComponent<Bullet>().InitializeBullet(mouseDir);
        }
    }
}
