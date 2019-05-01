using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelData : MonoBehaviour
{
    public static LevelData instance = null;

    public static float averageTime = 0.0f;
    public static int difficulty = 0;

    Scene activeScene, newScene;

    private void Start()
    {
        StartGame();
        activeScene = SceneManager.GetActiveScene();
        CheckActiveScene();
    }

    private void Update()
    {
        newScene = SceneManager.GetActiveScene();


        if (newScene != activeScene)
        {
            activeScene = newScene;
            CheckActiveScene();
        }
    }

    void CheckActiveScene()
    {
        if(activeScene.name == "Test Level Scene1")
        {
            averageTime = 10.85f;
            difficulty = 7;
        }
        else if(activeScene.name == "Test Level Scene2")
        {
            averageTime = 9.92f;
        }
    }

    void StartGame()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

}
