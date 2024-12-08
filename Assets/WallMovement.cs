using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f; // Speed of vertical movement
    [SerializeField] float upperBoundary = 5f; // Maximum Y position
    [SerializeField] float lowerBoundary = 0; // Minimum Y position
    private bool movingUp = true; // Direction of movement

    void Update()
    {
        // Move the wall vertically
        if (movingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y >= upperBoundary)
            {
                movingUp = false; // Switch direction
            }
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y <= lowerBoundary)
            {
                movingUp = true; // Switch direction
            }
        }
    }
}

