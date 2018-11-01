using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

    [SerializeField] float TimeToSelfDestruct;

	void Start () 
	{
        Destroy(gameObject, TimeToSelfDestruct);
	}
}
