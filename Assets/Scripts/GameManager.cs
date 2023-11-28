using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;
    public int score = 0;

    private void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        UpdateScore(); // Assuming this method doesn't need an argument
    }

    public void UpdateScore()
    {
        // Update the score when prefabs accumulate in the box
        scoreText.text = "Score: " + score;
    }

    public void MergePrefabs(PrefabController prefab1, PrefabController prefab2, int newPrefabNumber)
    {
        // Handle the merging logic (e.g., instantiate a new prefab with the newPrefabNumber)
        // Update the score based on the new prefab's point value
        UpdateScore();
    }

    public void GameOver()
    {
        // Handle game over logic (e.g., show game over panel)
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
}
