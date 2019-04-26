using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public List<GameObject> playerObjects;
    public List<GameObject> enemies;
    public Vector3[] spawnPoints;
    public GameObject enemyPrefab;
    public GameObject enemyHolder;
    public GameObject plane;
    public float spawnRate = 0.1f;
    public int maxEnemies= 20;
    bool EnemySpawningActive =true;
    int enemyID = 1;

void Awake(){
    if(enemyHolder == null){
        enemyHolder = new GameObject("Enemy holder");
    }
}
    void Start()
    {
        //PlayerPos
        playerObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        enemies = new List<GameObject>(maxEnemies);

        StartCoroutine(SpawningEnemies());

    }

    IEnumerator SpawningEnemies()
    {
        while(EnemySpawningActive){
            if (enemies.Count < maxEnemies){
            yield return new WaitForSeconds(1/spawnRate);
                SpawnEnemy();
            }
            else
            {
                yield return null;
            }
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count<maxEnemies){

        }
    }


    void SpawnEnemy()
    {
        //This function needs a lot of changes but it'll work for now

        //get bounds of `plane`
        //obviously this will have to change and we might manually put in spawn points?
        //or spawn bounds (and force enemies to spawn at least x units away from all players)
        Debug.Log(plane.ToString());
        float scale = 0.5f;
        float planeX = plane.GetComponent<Renderer>().bounds.size.x / 2;
        float planeY = plane.GetComponent<Renderer>().bounds.size.y / 2;
        float planeZ = plane.GetComponent<Renderer>().bounds.size.z / 2;

        //get the center of plane.
        Vector3 center = plane.transform.position;

       

        //get random points within the bounds of the plane
        float targetCoordsX = center.x + UnityEngine.Random.Range(-planeX * scale, planeX * scale);
        float targetCoordsY = center.y + scale;
        float targetCoordsZ = center.z + UnityEngine.Random.Range(-planeZ * scale, planeZ * scale);

        Vector3 spawnPosition = new Vector3(targetCoordsX, targetCoordsY, targetCoordsZ);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)),enemyHolder.transform);
        enemies.Add(newEnemy);
        newEnemy.name = "Enemy "+ enemyID.ToString();
        Debug.Log(newEnemy);
        enemyID++;
    }
}
