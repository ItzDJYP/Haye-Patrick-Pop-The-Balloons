using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WallCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object hitting the wall is a laser
        if (collision.CompareTag("Laser"))
        {
            Destroy(collision.gameObject); // Destroy the laser
        }
    }
}
