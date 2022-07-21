using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    GameUIController gameUIController;
    PauseMenuController pauseMenuController;

    void Awake() {
        gameUIController = FindObjectOfType<GameUIController>();
        pauseMenuController = FindObjectOfType<PauseMenuController>();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameUIController.gameObject.SetActive(true);
        pauseMenuController.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
