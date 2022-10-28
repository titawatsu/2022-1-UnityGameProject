using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseUi;
    [SerializeField] private GameManager gameManager;
    public AudioSource bgSound;

    public static bool paused = false;

    private PauseAction pauseAction;
    

    private void Awake()
    {
        pauseAction = new PauseAction();
        
    }

    private void OnEnable() => pauseAction.Enable();

    private void OnDisable() => pauseAction.Disable();

    private void Start()
    {
        pauseAction.PauseGame.Escape.performed += _ => DeterminePause(); // for check pause/ resume statement.
        ResumeGame();
    }
    
    private void DeterminePause() // funtions about game states
    {
        if (paused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        bgSound.Pause();
        paused = true;
        pauseUi.SetActive(true);

        //AudioListener.pause = true; for pause all sound which make button sound mute
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        bgSound.UnPause();
        paused = false;
        pauseUi.SetActive(false);

        //AudioListener.pause = false;
    }

    public void GotoMainmenuButton() => gameManager.LoadLevel(0); // load main menu level 

}
