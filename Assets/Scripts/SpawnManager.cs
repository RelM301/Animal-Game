using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint; // Set this to the position where you want to spawn prefabs
    public GameObject[] prefabArray; // Array of prefabs in order
    private GameObject currentPrefab; // The currently spawned prefab

    private void Start()
    {
        StartCoroutine(SpawnPrefabs());
    }

    private IEnumerator SpawnPrefabs()
    {
        for (int i = 0; i < prefabArray.Length; i++)
        {
            currentPrefab = SpawnPrefab(i);

            // Wait for mouse button release before spawning the next prefab
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));

            // Additional logic after releasing prefab (if needed)
        }
    }

    private GameObject SpawnPrefab(int prefabIndex)
    {
        GameObject prefabToSpawn = prefabArray[prefabIndex];
        return Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
    }

    private void Update()
    {
        // Dragging behavior: Move the spawner left or right based on mouse movement
        if (currentPrefab != null)
        {
            float mouseX = Input.GetAxis("Mouse X");
            currentPrefab.transform.position += new Vector3(mouseX, 0f, 0f);
        }
    }
}
