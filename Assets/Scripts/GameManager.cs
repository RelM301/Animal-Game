using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public Text scoreText;
    public Text finalScoreText;
    public Text highestScoreText;
    public GameManager gameManager;
    public SpawnManager spawnManager;
    private int score = 0;


    private void Start()
    {
        highestScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    private void Update()
    {
        UpdateScoreDisplay();
    }

    public void UpdateScore(int value)
    {
        score += value;
        UpdateScoreText();
    }
    private void UpdateScoreDisplay()
    {
        scoreText.text = score.ToString();
        finalScoreText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
            highestScoreText.text = score.ToString();
        }
    }
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
        Debug.Log("Score reset to 0.");
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
        ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        spawnManager.enabled = false;
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        pausePanel.SetActive(false);
        spawnManager.enabled = true;
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        print("Exit");
#endif
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }
}
