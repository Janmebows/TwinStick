using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public List<Vector3> playerPositions;
    public Vector3[] spawnPoints;
    void Start()
    {
        playerPositions = new List<Vector3>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players){
            playerPositions.Add(player.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
