using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private Rigidbody2D rigidbody2D;
    private bool active = true;
    [SerializeField] private int dropSpeed = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && active == true)
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        // Prevent pickup being double dipped on
        active = false;
        
        // Spawn a cool effect
        Animator animator = GetComponent<Animator>();
        animator.Play("Shield Picked Up");

        // Apply effect to player
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.AddShieldHealth(gameSession.shieldLayer01);
        gameSession.AddToScore(1000);
        

        // Remove power up object
        Destroy(gameObject, 1f);
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(transform.position.x, -dropSpeed);
    }
}
