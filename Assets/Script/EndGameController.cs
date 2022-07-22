using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public static bool gameOver;
    private GameUIController gameUIController;
    private EndGameController endGameController;

    void Awake()
    {
        gameOver = false;
        gameUIController = FindObjectOfType<GameUIController>();
        endGameController = FindObjectOfType<EndGameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        print("gameOver =" + gameOver);
        if (gameOver)
        {
            Time.timeScale = 0;
            endGameController.gameObject.SetActive(true);
            gameUIController.gameObject.SetActive(false);
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
