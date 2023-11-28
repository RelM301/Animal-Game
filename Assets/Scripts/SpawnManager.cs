using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint; // Set this to the position where you want to spawn prefabs
    public GameObject[] prefabArray; // Array of prefabs in order

    private void Start()
    {
        StartCoroutine(SpawnPrefabs());
    }

    private IEnumerator SpawnPrefabs()
    {
        for (int i = 0; i < prefabArray.Length; i++)
        {
            SpawnPrefab(i);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); // Wait for left mouse button click
        }

        // Additional logic after spawning all prefabs (if needed)
    }

    private void SpawnPrefab(int prefabIndex)
    {
        GameObject prefabToSpawn = prefabArray[prefabIndex];
        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
