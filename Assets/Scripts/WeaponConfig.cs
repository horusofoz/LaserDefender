using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConfig : MonoBehaviour {

    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;
    [SerializeField] List<float> projectileDirectionList;
    private float checkForChildrenPeriod =  1f;
    private float timePassed;

    public float GetProjectileSpeed()
    {
        return projectileSpeed;
    }

    public float GetProjectileFiringPeriod()
    {
        return projectileFiringPeriod;
    }

    public List<float> GetProjectileDirections()
    {
        return projectileDirectionList;
    }

    public void DestroyWhenProjectilesExpended()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= checkForChildrenPeriod)
        {
            DestroyWhenProjectilesExpended();
        }
    }
}
