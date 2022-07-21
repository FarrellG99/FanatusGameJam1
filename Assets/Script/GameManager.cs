using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameUIController gameUIController;
    PauseMenuController pauseMenuController;

    void Awake()
    {
        gameUIController = FindObjectOfType<GameUIController>();
        pauseMenuController = FindObjectOfType<PauseMenuController>();
    }

    void Start() {
        gameUIController.gameObject.SetActive(true);
        pauseMenuController.gameObject.SetActive(false);
    }
}
