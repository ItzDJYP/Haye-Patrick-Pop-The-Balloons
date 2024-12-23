using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    [SerializeField] float SPEED = 5;
    [SerializeField] AudioClip hitSound;
    [SerializeField] private bool isMovingRight;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        // Set initial volume for the AudioSource based on saved SFX volume
        if (audioSource != null)
        {
            float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f); // Default to 1.0f if not set
            audioSource.volume = savedVolume;
        }
        GameObject player = GameObject.FindWithTag("Player");
        isMovingRight = player.transform.localScale.x > 0;
        float horizontalSpeed = isMovingRight ? SPEED : -SPEED;
        rb.velocity = new Vector2(horizontalSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the laser hits an AI object
        if (collision.CompareTag("AI"))
        {
            AIMovement balloon = collision.GetComponent<AIMovement>();
            if (balloon != null)
            {
                Debug.Log("collision");
                balloon.PopBalloon();
            }
            //Destroy(collision.gameObject); // Destroy the AI
            Destroy(gameObject); // Destroy the laser
            // Destroy the AI and the laser
            Debug.Log("Hit object: " + collision.gameObject.name);
        }
    }
}
