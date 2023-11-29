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
}
