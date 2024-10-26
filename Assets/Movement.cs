using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int Speed = 10;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] const float jumpForce = 500.0f;
    [SerializeField] bool isJumpPressed = true;
    [SerializeField] bool isGrounded = true;
    [SerializeField] GameObject laserPrefab; // Drag your laser prefab here in the Inspector
    [SerializeField] Transform firePoint;    // Assign the fire point (where the laser will spawn) in the Inspector
    [SerializeField] float fireRate = 0.5f;  // Time between each shot
    [SerializeField] private float nextFireTime = 0f;

    // Start is called before the first frame update
    void Start(){
        if(rigid == null){
            rigid = GetComponent<Rigidbody2D>();
        }
    } 

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        isJumpPressed = Input.GetButtonDown("Jump");
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            ShootLaser();
            nextFireTime = Time.time + fireRate; // Control the fire rate
        }
    }

    // called potentially many times per frame -- better than Update for physics and movement
    void FixedUpdate() {
        rigid.velocity = new Vector2 (movement * Speed, rigid.velocity.y);
        if(movement < 0 && isFacingRight || movement > 0 && !isFacingRight){
            Flip();
        }
        if(isJumpPressed && isGrounded){
            Jump();
        }
    }

    // called when to flip the model if the user is going a different direction
    void Flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    // called when to jump
    private void Jump(){
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2 (0, jumpForce));
        isGrounded = false;
    }

    // detects if the model is on the ground or in the air
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }
    void ShootLaser()
    {
        // Instantiate the laser at the fire point's position and rotation
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }
}
