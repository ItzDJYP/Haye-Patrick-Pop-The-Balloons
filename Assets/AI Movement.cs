using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
public class AIMovement : MonoBehaviour
{
    // Expansion settings
    [SerializeField] private float expansionRate = 1.1f;  // Base growth rate (1.1 = 10% growth each time)
    [SerializeField] private float maxSize = 5f;          // Maximum size before balloon stops expanding
    [SerializeField] private float expansionInterval = 0.5f; // Interval in seconds between each growth step
    private bool isPopped = false;
    // AI Movement Settings
    [SerializeField] const int SPEED = 10;
    [SerializeField] float AImovement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] float leftBoundary = -5f;
    [SerializeField] float rightBoundary = 5f;
    [SerializeField] GameObject controller;
    private Scorekeeper scorekeeper;
    // Audio Stuff
    [SerializeField] private AudioClip popSound; // Assign the pop sound in the Inspector
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){
            rigid = GetComponent<Rigidbody2D>();
        }
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("AI");
        }
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f); // Default to 1.0f if not set
            audioSource.volume = savedVolume;
        }
        scorekeeper = FindObjectOfType<Scorekeeper>();
        InvokeRepeating("ExpandBalloon", 1f, expansionInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= leftBoundary)
        {
            AImovement = 1;
        }
        else if (transform.position.x >= rightBoundary)
        {
            AImovement = -1;
        }
    }
    void ExpandBalloon()
    {
        if (isPopped) return;

        // Increase the balloon's size exponentially
        transform.localScale *= expansionRate;

        // Check if balloon size exceeds the maximum size and stop expanding
        if (transform.localScale.x >= maxSize)
        {
            PopBalloon();
        }
    }
    public void PopBalloon()
    {
        isPopped = true; // Mark the balloon as popped
        CancelInvoke("ExpandBalloon");  // Stop expanding

        // Add additional effects here, like playing a sound or animation
        if (popSound != null && audioSource != null)
        {
            float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f); // Load the saved volume
            audioSource.volume = savedVolume; // Update the volume before playing the sound

        }

        if (scorekeeper != null)
        {
            scorekeeper.BalloonPopped();
        }
        Destroy(gameObject); // Destroy the balloon object (pop it)
    }

    void Flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

     void FixedUpdate() {
        rigid.velocity = new Vector2 (AImovement * SPEED, rigid.velocity.y);
        if(AImovement < 0 && isFacingRight || AImovement > 0 && !isFacingRight){
            Flip();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //what should happen on collision?
        //1. score should increase
        //2. sound effect should play
        //3. coin should be removed from the scene
        
        //controller.GetComponent<Scorekeeper>().AddPoints();
        if(collision.CompareTag("Laser"))
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            PopBalloon();
        }
    }
}
