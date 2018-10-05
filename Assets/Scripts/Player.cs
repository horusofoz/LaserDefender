using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Configuration Parameters
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float padding = .5f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Use this for initialization
    void Start () 
	{
        SetUpMoveBoundaries();

        

	}

    // Update is called once per frame
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
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
}
