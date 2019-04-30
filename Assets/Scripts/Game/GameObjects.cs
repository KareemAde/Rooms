using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameObjects : MonoBehaviour
{
    public static bool passedGoal;
    public static bool passedHazard;
    protected Collider2D space;
    protected int pass;

    void Start()
    {

        passedGoal = false;
        passedHazard = false;
        space = GetComponent<Collider2D>();
    }

    protected virtual void CheckPass(){ }

    void Update()
    {
        Debug.Log(passedHazard);
        Debug.Log(passedGoal);
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        CheckPass();

        if (pass == 8)
        {
            Debug.Log("Hazard Passed");
            passedHazard = true;
        }
        else if (pass == 0)
        {
            passedGoal = true;
        }
    }
}
