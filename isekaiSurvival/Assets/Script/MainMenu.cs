
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void StartButton()
    {
        Time.timeScale = 1f; //to force running game at default timescale, for debug pause game - in-game time scale bug
        SceneManager.LoadScene("Gameplay");
    }

    private void ExitButton()
    {
        //------For Debug exit aplication------//
        Debug.Log("Application has Quit");
        //-------------------------------------//

        Application.Quit();
    }
}
