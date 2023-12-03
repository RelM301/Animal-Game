using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabController : MonoBehaviour
{
    private string intheSpawner = "y";
    private string timeToCheck = "n";
    private SpawnManager spawnManager;
    private GameManager gameManager;
    public int prefabValue;

    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        gameManager = FindObjectOfType<GameManager>();
        if (transform.position.y < 1.2)
        {
            intheSpawner = "n";
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void Update()
    {
        if (intheSpawner == "y")
        {
            transform.position = spawnManager.spawnPoint.position;
        }

        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            intheSpawner = "n";
            spawnManager.SpawnedYet = "n";
            StartCoroutine(checkGameOver());
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            SpawnManager.newSpawnPos = transform.position;
            spawnManager.NewPrefab = "y";
            SpawnManager.whichPrefab = int.Parse(gameObject.tag);
            spawnManager.MergeSound();
            //Logic of the score
            gameManager.UpdateScore(prefabValue);
            // Destroy the object
            Destroy(gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.name == "Top") && (timeToCheck == "y"))
        {
            gameManager.GameOver();
            Debug.Log("Game Over");
        }
    }

    IEnumerator checkGameOver()
    {
        yield return new WaitForSeconds(1f);
        timeToCheck = "y";
    }
}

