using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour {

    public GameObject projectile;

    public float fireDelta;

    private GameObject newProjectile;

    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }
}
