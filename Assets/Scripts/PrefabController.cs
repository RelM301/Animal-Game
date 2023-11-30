using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour
{
    private string intheSpawner = "y";
    private SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        
    }

    private void Update()
    {
        if (intheSpawner == "y" && spawnManager != null)
        {
            transform.position = spawnManager.spawnPoint.position;
        }

        if(Input.GetMouseButtonUp(0))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            intheSpawner = "n";
            spawnManager.SpawnedYet = "n";
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            // Store the position before destroying the object
            Vector3 spawnPosition = transform.position;

            // Update spawnManager properties
            spawnManager.newSpawnPoint = transform;
            spawnManager.NewPrefab = "y";
            SpawnManager.whichPrefab = int.Parse(gameObject.tag);

            // Destroy the object
            Destroy(gameObject);
        }
    }
    
}

