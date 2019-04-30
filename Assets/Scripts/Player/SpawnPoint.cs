using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject player;

    private Transform spawn;

    private void Start()
    {
        spawn = GetComponent<Transform>();
        Instantiate(player, spawn.transform.position, Quaternion.identity);
    }

    public void Respawn()
    {
        Instantiate(player, spawn.transform.position, Quaternion.identity);
    }

}
