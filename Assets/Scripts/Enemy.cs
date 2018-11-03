using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue;
    [SerializeField] GameObject boostItem = null;

    [Header("Projectile")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject weapon;
    [SerializeField] float projectileSpeed = 10f;

    [Header("Sound Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;

    private bool onScreen = false;


    // Use this for initialization
    void Start () 
	{
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}
	 
	// Update is called once per frame
	void Update () 
	{
        CountDownAndShoot();
	}

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f && onScreen)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        // Instantiate weapon
        GameObject projectile = Instantiate(weapon, transform.position, Quaternion.identity) as GameObject;

        // Get list of projectile directions
        List<float> projectileDirectionList = projectile.GetComponent<WeaponConfig>().GetProjectileDirections();

        // Get children of projectile GameObject
        List<Rigidbody2D> projectileRigidBodies = projectile.transform.GetComponentsInChildren<Rigidbody2D>().ToList();

        // Set rBodyCounter for iterating through projectDirectionList
        int rBodyCounter = 0;

        // For Each child Of projectile
        foreach (var rBody in projectileRigidBodies)
        {
            // Apply direction via Velocity
            rBody.velocity = new Vector2(projectileDirectionList[rBodyCounter], -projectileSpeed);

            // Iterate rBodyCounter
            rBodyCounter++;
        }
        SoundManager.Instance.TriggerEnemyShotSFX();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (onScreen)
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            if (!damageDealer)
            {
                return;
            }
            else
            {
                if (other.tag == "Projectile")
                {
                    Destroy(other);
                }
            }
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
        GameSession.Instance.AddToScore(scoreValue);
        SoundManager.Instance.TriggerEnemyDeadSFX();
        Destroy(gameObject);

        if(boostItem != null)
        {
            Instantiate(boostItem, transform.position, Quaternion.identity);
            Debug.Log("Spawning boost: " + boostItem.name);
        }

        if(gameObject.name.StartsWith("Boss"))
        {
            SceneLoader.Instance.LoadGameOver();
        }
    }

    public void SetBoostItem(GameObject boost)
    {
        boostItem = boost;
    }

    private void OnBecameVisible()
    {
        onScreen = true;
    }

    private void OnBecameInvisible()
    {
        onScreen = false;
    }
}
