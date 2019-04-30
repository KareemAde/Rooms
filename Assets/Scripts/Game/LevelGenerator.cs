using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject levelblock;
    public int size;

	// Use this for initialization
	void Start () {
        GenerateBox();
	}

    void GenerateBox()
    {
        print(levelblock.transform.localScale.x);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Instantiate(levelblock, new Vector3(-(levelblock.transform.localScale.x) * j, -(levelblock.transform.localScale.y) * i, 0), Quaternion.identity);
            }
        }
    }

    /*void LevelGenerator()
    {

    }*/
	
	// Update is called once per frame
	void Update () {
		
	}
}
