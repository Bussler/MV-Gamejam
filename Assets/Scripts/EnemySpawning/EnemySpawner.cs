using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies = new GameObject[1];
    public ArrayList spawnedEnemies= new ArrayList();

    public bool cleared;
    void Start()
    {
       
    }

    public void Update()
    {
        if (spawnedEnemies.Count <=0)
        {
            cleared = true;
        }
        else
        {
            cleared = false;
        }
    }

    public void spawnEnemies(int numEnemies)
    {
        SpawnArea[] spawnPointsArray = GameObject.FindObjectsOfType<SpawnArea>();
        List<SpawnArea> spawnPoints = new List<SpawnArea>(spawnPointsArray);


        foreach(GameObject g in spawnedEnemies)
        {
            Destroy(g);
        }
        spawnedEnemies.Clear();
        for (int i = 0; i< numEnemies; i++)
        {
            //get random enemy to spawn
            GameObject EnemyToSpawn = enemies[Random.Range(0, enemies.Length)];

            //get random spawn area to spawn in
            if (spawnPoints.Count == 0)
                break;

            int rand = Random.Range(0, spawnPoints.Count);
            SpawnArea spawnPoint = spawnPoints[rand];

            //calculate spawn point in spawn area
            Vector2 center = spawnPoint.gameObject.transform.position;
            Vector2 size = spawnPoint.gameObject.GetComponent<SpriteRenderer>().bounds.size;
            size -= new Vector2(0.5f, 0.5f); // boundary anpassung, TODO besser machen?

            Vector2 spawnPointPosition = new Vector2(0,0);

            bool isLegalToSpawn = true;
            GameObject[] enemiesToCheck = GameObject.FindGameObjectsWithTag("Enemy"); //all enemies in the scene to check collision with

            do//check if we don't collide with other enemies
            {
                isLegalToSpawn = true;
                spawnPointPosition = randomPointInBox(center, size); //get random point within the area

                //check if spawn is legal
                Bounds curBounds = new Bounds(new Vector3(spawnPointPosition.x, spawnPointPosition.y, -1), EnemyToSpawn.GetComponent<SpriteRenderer>().bounds.extents*2); //bounds of our currently spawned enemy

                foreach (GameObject enemy in enemiesToCheck)
                {
                    if (enemy.GetComponent<SpriteRenderer>().bounds.Intersects(curBounds))//intersection, illegal spawn!
                    {
                        isLegalToSpawn = false;
                        Debug.Log("Found intersection");
                        break;
                    }
                }
            }
            while (!isLegalToSpawn);

            GameObject spawnedEnemy = Instantiate(EnemyToSpawn, new Vector3(spawnPointPosition.x, spawnPointPosition.y, -1), Quaternion.identity);//finally spawn if we have a legit spawn pos
            spawnedEnemies.Add(spawnedEnemy);
            spawnPoints[rand].spawnEnemies--; //delete enemies to spawn
            if (spawnPoints[rand].spawnEnemies == 0)
                spawnPoints.RemoveAt(rand);

        }


    }

    private Vector2 randomPointInBox(Vector2 center, Vector2 size)
    {
        return center + new Vector2((Random.value - 0.5f) * size.x, (Random.value - 0.5f) * size.y);
    }

}
