using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour {

    private Rigidbody2D rigidbody2D;
    private bool active = true;
    [SerializeField] private int dropSpeed = 3;
    [SerializeField] int healthValue = 25;
    [SerializeField] int scoreValue = 1000;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && active == true)
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
        animator.Play("Boost Collected");

        // Apply effect to player
        GameSession.Instance.AddHealth(healthValue);
        GameSession.Instance.AddToScore(scoreValue);

        // Remove power up object
        Destroy(gameObject, 1f);
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.down * dropSpeed;
    }
}
