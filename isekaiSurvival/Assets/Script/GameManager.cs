using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PauseController pauseController;
    public GameObject GameOverUi;
    public TimeManager timeManager;

    #region START_UPDATE
    private void Start()
    {
        SetGameResume();
    }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        
        else instance = this;
        
    }
    #endregion
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

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ProcessPlayerDeath()
    {
        GameOver();
    }

    private void GameOver()
    {

        Time.timeScale = 0f;
        PauseController.paused = true; // if use pauseController.paused = true;, it cannot be accessed with an instance reference; qualify it with a type name instead (PauseController)

        pauseController.bgSound.Pause();

        Destroy(this.gameObject);
        GameOverUi.SetActive(true);

    }

}
