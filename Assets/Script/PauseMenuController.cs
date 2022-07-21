using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    GameUIController gameUIController;
    PauseMenuController pauseMenuController;

    void Awake() {
        gameUIController = FindObjectOfType<GameUIController>();
        pauseMenuController = FindObjectOfType<PauseMenuController>();
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
        gameUIController.gameObject.SetActive(true);
        pauseMenuController.gameObject.SetActive(false);
    }
}
