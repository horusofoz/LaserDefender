﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Shredder hit by " + collision.gameObject.name);
        Destroy(collision.gameObject);
    }
}
