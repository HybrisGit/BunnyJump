using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkonnonSpawner : MonoBehaviour {

    public GameObject projectileToSpawn;
    public Vector2 spawnFrequency;
    public Vector3 spawnOffset;

    private float timeCounter;
    private float timeToSpawn;
    // Use this for initialization
    void Start () {
        timeCounter = 0;
        timeToSpawn = Random.Range(spawnFrequency.x, spawnFrequency.y);

    }
	
	// Update is called once per frame
	void Update () {

        timeCounter += Time.deltaTime;
        if (timeCounter >= timeToSpawn)
        {
            timeToSpawn = Random.Range(spawnFrequency.x, spawnFrequency.y);
            GameObject projectile = Instantiate(projectileToSpawn, transform.position + spawnOffset, Random.rotation);
        }
    }
}
