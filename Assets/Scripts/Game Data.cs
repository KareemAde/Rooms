using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    Queue levels;

    float gameTime = 0.0f;
    float levelTime = 0.0f;

    int deathCount = 0;
    int levelsCompleted = 0;

    bool gameOver = false;

    void Start()
    {
        gameTime = Time.time;
    }

    void Update()
    {
        CheckGameOver();
    }

    void CheckCompletedLevel()
    {
        // If the level is complete
        // Unload the current level
        levelsCompleted++;
        // Load the next level in the queue
    }

    void CheckGameOver()
    {
        if (deathCount == 2)
            gameOver = true;
    }
    void RestartLevelTime()
    {
        // Record levelTime and reset levelTime to zero
    }
}
