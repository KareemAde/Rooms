using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyDeterminator : MonoBehaviour
{
    public static DifficultyDeterminator instance = null;

    double skillLevel = 0;
    public int penalty;
    float averageLevelTime = 0; //Collect from each level

    public static int deathCount = 0;
    public static float levelTime = 0.0f;
    public static int levelsCompleted = 0;

    private void Awake()
    {
        StartGame();
    }

    private void Update()
    {
        Determinator();
    }

    public void Determinator()
    {
        averageLevelTime = LevelData.averageTime;

        if (levelTime < averageLevelTime)
        {
            Debug.Log("Skill Level: " + levelTime);
        }
        else
        {
            Debug.Log("Death Count: " + deathCount);
            Debug.Log("Level Time: " + levelTime);
            Debug.Log("Average Level Time: " + averageLevelTime);

            skillLevel = 10 - ((levelTime + (deathCount * penalty)) / averageLevelTime);
            Debug.Log("Skill Level: " + skillLevel);
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
