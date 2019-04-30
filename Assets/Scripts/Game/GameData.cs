using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameData : MonoBehaviour
{
    Queue levels;

    public static GameData instance = null;

    private float gameTime = 0.0f;
    private float ellapesed = 0.0f;
    private float lap = 0.0f;
    public static float levelTime = 0.0f;

    public static int deathCount = 0;
    public static int levelsCompleted = 0;

    private string[] nextLevels = { "Test Level Scene1", "Test Level Scene2", "Test Level Scene3" };
    private int count = 0;

    //Past Performance
    int[] deathPerLevel = { 0, 0, 0 };
    float[] timePerLevel = { 0f, 0f, 0f };

    void Awake()
    {
        StartGame();
    }

    void Update()
    {
        NextLevel();
    }

    void NextLevel()
    {
        if (GameObjects.passedGoal)
        {
            // Make function in DD to determine next level
            ellapesed = Time.time - gameTime;

            levelTime = ellapesed - lap;

            deathPerLevel[count] = deathCount;
            timePerLevel[count] = levelTime;
            SendToAI();

            lap = levelTime;
            levelTime = 0.0f;

            levelsCompleted++;
            count++;

            Debug.Log("Deaths on Level" + count + ": " + deathPerLevel[count - 1]);
            Debug.Log("Time to Beat Level " + count + ": " + timePerLevel[count - 1]);

            SceneManager.LoadScene(nextLevels[count]);
            GameObjects.passedGoal = false;


        }
        else if (GameObjects.passedHazard)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

            GameObjects.passedHazard = false;
            Debug.Log(++deathCount);
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

        gameTime = Time.time;
    }

    void SendToAI()
    {
        DifficultyDeterminator.deathCount = deathCount;
        DifficultyDeterminator.levelTime = levelTime;
        DifficultyDeterminator.levelsCompleted = levelsCompleted;
    }

}
