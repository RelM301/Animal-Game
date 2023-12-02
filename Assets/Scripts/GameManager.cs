using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

   public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void PauseGame()
    {

    }

    void ExitGame()
    {
#if UNITY_EDITOR
        print("Exit");
#endif
        Application.Quit();
    }

    void Menu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }
}
