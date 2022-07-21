using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    GameUIController gameUIController;
    PauseMenuController pauseMenuController;

    void Awake() {
        gameUIController = FindObjectOfType<GameUIController>();
        pauseMenuController = FindObjectOfType<PauseMenuController>();
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
        gameUIController.gameObject.SetActive(false);
        pauseMenuController.gameObject.SetActive(true);
    }
}
