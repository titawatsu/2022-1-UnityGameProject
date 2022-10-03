using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PauseController pauseController;
    public GameObject GameOverUi;

    private void Start()
    {
        SetGameResume();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void SetGameResume()
    {
        pauseController.ResumeGame(); //For making Time.timeScale = 1f;
        GameOverUi.SetActive(false);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadNextLevel()
    {
        int nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneBuildIndex == SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(0);

        }
        else
        {
            SceneManager.LoadScene(nextSceneBuildIndex);
        }
    }

    public void ProcessPlayerDeath()
    {

        GameOver();
    }

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        PauseController.paused = true;
        GameOverUi.SetActive(true);
    }

}
