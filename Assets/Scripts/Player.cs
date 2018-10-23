using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Player : MonoBehaviour {

    // Configuration Parameters
    [Header("Player Movement")]
    [SerializeField] int moveSpeed;
    [SerializeField] float padding = .5f;

    [Header("Projectile")]
    GameObject weapon;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;

    [SerializeField] SoundManager soundManager;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    void Start () 
	{
        SetUpMoveBoundaries();
        SetPlayerStats();
        
    }

    private void SetPlayerStats()
    {
        SetWeapon();
        SetSpeed();
    }

    void Update () 
	{
        Move();
        Fire();
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal");
        var deltaY = Input.GetAxis("Vertical");
        var newXPos = Mathf.Clamp(transform.position.x + deltaX * Time.deltaTime * moveSpeed, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY * Time.deltaTime * moveSpeed, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameGamera = Camera.main;
        xMin = gameGamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameGamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameGamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameGamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private IEnumerator FireContinuously()
    {
        while(true)
        {
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
                rBody.velocity = new Vector2(projectileDirectionList[rBodyCounter], projectileSpeed);

                // Iterate rBodyCounter
                rBodyCounter++;
            }
            soundManager.TriggerPlayerShotSFX();
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        GameSession.Instance.SubtractHealth(damageDealer.GetDamage());
        damageDealer.Hit();
        if(GameSession.Instance.GetHealth() <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        soundManager.TriggerPlayerDeadSFX();
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
        SceneLoader.Instance.LoadGameOver();
    }

    public void SetWeapon()
    {
        GameObject NewWeapon = GameSession.Instance.GetWeapon();
        this.weapon = NewWeapon;
        projectileFiringPeriod = weapon.GetComponent<WeaponConfig>().GetProjectileFiringPeriod();
        projectileSpeed = weapon.GetComponent<WeaponConfig>().GetProjectileSpeed();
        //Debug.Log("Player weapon set to " + weapon.gameObject.name);
    }

    public void SetSpeed()
    {
        moveSpeed = GameSession.Instance.GetPlayerSpeed();
        //Debug.Log("Player Speed After Update: " + moveSpeed);
    }
}
