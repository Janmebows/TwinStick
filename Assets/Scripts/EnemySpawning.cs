using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public List<Vector3> playerPositions;
    public Vector3[] spawnPoints;
    public GameObject enemy;
    public GameObject plane;

    void Start()
    {
        //PlayerPos
        playerPositions = new List<Vector3>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players){
            playerPositions.Add(player.transform.position);
        }

        //Spawn a bunch of baddies

        //get bounds of `plane`
        Debug.Log(plane.ToString());
        float scale = 0.5f;
        float planeX = plane.GetComponent<Renderer>().bounds.size.x / 2;
        float planeY = plane.GetComponent<Renderer>().bounds.size.y / 2;
        float planeZ = plane.GetComponent<Renderer>().bounds.size.z / 2;

        //get the center of plane.
        Vector3 center = plane.GetComponent<Renderer>().bounds.center;

        //get random points within the bounds of the plane
        float targetCoordsX = center.x + Random.Range(-planeX * scale, planeX * scale);
        float targetCoordsY = center.y + Random.Range(-planeY * scale, planeY * scale);
        float targetCoordsZ = center.z + Random.Range(-planeZ * scale, planeZ * scale);

        Vector3 spawnPosition = new Vector3(targetCoordsX, targetCoordsY, targetCoordsZ);

        //limit number of enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 10)
        {
            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));

        }
        int count = 0;
        foreach(GameObject baddy in enemies)
        {
            baddy.name = "Enemy " + count;
            Debug.Log(baddy);
            count++;

        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
       

    }
}
