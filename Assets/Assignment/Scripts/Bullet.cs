using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Bullet : MonoBehaviour
{
    float speed = 5;
    Vector3 moveDirection;
    void MoveObject()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime); // Move bullet in direction of mouse at set speed
    }

    public void InitializeBullet(Vector3 direction)
    {
        moveDirection = direction; // Set the movement direction from the spawner
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // If bullet off screen destroy
    }
}

