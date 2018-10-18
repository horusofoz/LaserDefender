using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConfig : MonoBehaviour {

    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;

    public float GetProjectileSpeed()
    {
        return projectileSpeed;
    }

    public float GetProjectileFiringPeriod()
    {
        return projectileFiringPeriod;
    }
}
