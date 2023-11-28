using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour
{
    public int prefabNumber = 1; // Unique identifier for each prefab
    public int pointValue = 10; // Point value for each prefab
    private GameManager gameManager;

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PrefabController otherPrefab = other.GetComponent<PrefabController>();

        if (otherPrefab != null)
        {
            if (prefabNumber == otherPrefab.prefabNumber)
            {
                MergePrefabs(otherPrefab);
            }
            else
            {
                // Handle when different prefabs touch (e.g., accumulate in the box)
                gameManager.UpdateScore(); // Assuming this method doesn't need an argument
            }
        }
        else
        {
            // Handle when a prefab touches the top border (game over condition)
            gameManager.GameOver();
        }
    }

    private void MergePrefabs(PrefabController otherPrefab)
    {
        int newPrefabNumber = prefabNumber + 1;

        // Handle merging logic here (spawn a new prefab, update score, etc.)
        gameManager.MergePrefabs(this, otherPrefab, newPrefabNumber);

        // Destroy the current prefabs after merging
        Destroy(gameObject);
        Destroy(otherPrefab.gameObject);
    }
}
