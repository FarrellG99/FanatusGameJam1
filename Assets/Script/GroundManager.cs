using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public Transform target;
    public GameObject[] groundPrefabs;
    public float zSpawn = 0;
    public float tileLength = 100;

    private int counter = 1;
    private GameUIController gameUIController;
    public EndGameController endGameController;

    // Start is called before the first frame update
    void Start()
    {
        gameUIController = FindObjectOfType<GameUIController>();
        endGameController = FindObjectOfType<EndGameController>();

        for (int i = 0; i < groundPrefabs.Length; i++)
        {
            spawnGround(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        print("end Game counter = " + counter);
        if (target.position.z >= zSpawn - 100)
        {
            for (int i = 0; i < groundPrefabs.Length; i++)
            {
                spawnGround(i);
            }

            print("end Game counter = " + counter);

            counter++;

            if(counter == 2)
            {
                endGame();
            }
        }
    }

    public void spawnGround(int groundIndex)
    {
        Instantiate(groundPrefabs[groundIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
    }

    private void endGame()
    {
        endGameController.gameOver = true;

        print("End Game Controller Game Over = " + endGameController.gameOver);

        if (endGameController.gameOver)
        {
            Time.timeScale = 0;
            endGameController.gameObject.SetActive(true);
            gameUIController.gameObject.SetActive(false);
        }
    }
}
