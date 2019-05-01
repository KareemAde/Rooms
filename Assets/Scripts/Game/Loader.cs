using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject AI;
    public GameObject levelData;

    private void Awake()
    {
        if (GameData.instance == null)
        {
            Instantiate(gameManager);
        }

        if (DifficultyDeterminator.instance == null)
        {
            Instantiate(AI);
        }

        if (LevelData.instance == null)
        {
            Instantiate(levelData);
        }
    }
}
