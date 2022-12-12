using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platformPrefab;

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public float timer = 0.5f;
    public bool isSpawning = true;

    // Use this for initialization
    void Start()
    {

        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < 10; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        canSpawn();
    }    

    void canSpawn()
    {
        if (isSpawning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                
                Instantiate(platformPrefab, new Vector3(Random.Range(-levelWidth, levelWidth), transform.position.y + 15, 0), Quaternion.identity);
                timer = 0.5f;
            }
        }
    }
    //check collision with platform and destroy it
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(collision.gameObject);
        }
    }
}
