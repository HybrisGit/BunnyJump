using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkonnonSpawner : MonoBehaviour {

    public GameObject projectileToSpawn;
    public Vector2 spawnFrequency;
    public Vector3 spawnOffset;

    private float lastSpawnTime;
    private float timeToSpawn;
    // Use this for initialization
    void Start () {
        lastSpawnTime = 0f;
        timeToSpawn = Random.Range(spawnFrequency.x, spawnFrequency.y);

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Time.time - this.lastSpawnTime > this.timeToSpawn)
        {
            timeToSpawn = Random.Range(spawnFrequency.x, spawnFrequency.y);
            GameObject projectile = Instantiate(projectileToSpawn, transform.position + spawnOffset, Quaternion.identity);

            Rigidbody2D rBody = projectile.GetComponentInParent<Rigidbody2D>();
            rBody.velocity += new Vector2(Random.Range(1.0f, 0.0f), Random.Range(0.0f, 1.0f)).normalized * 10;

            projectile.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
            this.lastSpawnTime = Time.time;
            timeToSpawn = Random.Range(spawnFrequency.x, spawnFrequency.y);
        }
    }
}
