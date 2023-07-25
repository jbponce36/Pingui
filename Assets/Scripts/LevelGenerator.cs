using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public GameObject[] obstaclePrefabs;
    public GameObject[] decorationPrefabs;
    public GameObject[] enemyPrefabs;
    public GameObject chestPrefab;
    public GameObject keyPrefab;
    
    public GameObject groundTiles;
    public GameObject obstacles;
    public GameObject decorations;
    public GameObject enemies;

    public int floorHeight = 4;

    public float rowWaitSeconds = 0.5f;
    public float tileWaitSeconds = 0.1f;
    public float fallingSpeed = 15f;
    public bool fallingObjects = true;
    
    void Start()
    {
        StartCoroutine(CreateStartingTiles());
    }

    IEnumerator CreateStartingTiles() 
    {
        for (int j = -3; j <= floorHeight; j++) 
        {
            CreateNewRowOfTilesOneByOne(j);
            yield return new WaitForSeconds(rowWaitSeconds);
        }

        for (int j = -3; j <= floorHeight; j++) 
        {
            //Don't create obstacles where the player spawns initially. Only decorations.
            if (j != 0) 
            {
                StartCoroutine(CreateTopOneByOne(j));
            }
            else 
            {
                StartCoroutine(CreateDecorationsOneByOne(j));
            }
            yield return new WaitForSeconds(rowWaitSeconds);
        }

        fallingObjects = false;
    }

    IEnumerator CreateTopOneByOne(int row)
    {
        //Instantiate one random obstacle at a random position
        int randomObstaclePosition = Random.Range(-3, 4);
        int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject randomPrefab = obstaclePrefabs[randomObstacleIndex];
        
        Instantiate(randomPrefab, new Vector3(randomObstaclePosition, row + 1, row), randomPrefab.transform.rotation, obstacles.transform);
        
        yield return new WaitForSeconds(tileWaitSeconds);
        
        //If we are at an even row, instantiate a second obstacle at a random position
        int randomObstaclePosition2 = randomObstaclePosition;
        if (row % 2 == 0) 
        {
            int randomObstacleIndex2 = Random.Range(0, obstaclePrefabs.Length);
            randomPrefab = obstaclePrefabs[randomObstacleIndex2];
            
            //Ensure random position is not the same as the first obstacle
            while (randomObstaclePosition == randomObstaclePosition2)
            {
                randomObstaclePosition2 = Random.Range(-3, 4);

                //If the both obstacles are trees, don't instantiate 2 trees next to each other (because they clip)
                if ((randomObstacleIndex == 5 || randomObstacleIndex == 6) && (randomObstacleIndex2 == 5 || randomObstacleIndex2 == 6))
                {
                    if (randomObstaclePosition == randomObstaclePosition2 + 1 || randomObstaclePosition == randomObstaclePosition2 - 1)
                    {
                        //Set the second obstacle position to the same so the while loop executes again
                        randomObstaclePosition2 = randomObstaclePosition;
                    }
                }
            }

            Instantiate(randomPrefab, new Vector3(randomObstaclePosition2, row + 1, row), randomPrefab.transform.rotation, obstacles.transform);
            yield return new WaitForSeconds(tileWaitSeconds);
        }

        //Instantiate a chest every 4 rows at a random position
        int randomChestPosition = randomObstaclePosition;
        if (row % 4 == 0) 
        {
            //Ensure it doesn't overlap obstacles
            while (randomChestPosition == randomObstaclePosition || randomChestPosition == randomObstaclePosition2)
            {
                randomChestPosition = Random.Range(-3, 4);
            }

            Instantiate(chestPrefab, new Vector3(randomChestPosition, row + 1, row), chestPrefab.transform.rotation, obstacles.transform);
            yield return new WaitForSeconds(tileWaitSeconds);
        }

        //Instantiate a key every 4 rows (2 rows higher than chest) at a random position
        int randomKeyPosition = randomObstaclePosition;
        if (row % 4 == 2) 
        {
            //Ensure it doesn't overlap obstacles
            while (randomKeyPosition == randomObstaclePosition || randomKeyPosition == randomObstaclePosition2 || randomKeyPosition == randomChestPosition)
            {
                randomKeyPosition = Random.Range(-3, 4);
            }

            Instantiate(keyPrefab, new Vector3(randomKeyPosition, row + 1, row), keyPrefab.transform.rotation, obstacles.transform);
            yield return new WaitForSeconds(tileWaitSeconds);
        }

        //Instantiate decorations with 25% chance every tile, not overlapping any other object.
        for (int i = -3; i <= 3; i++)
        {
            if (Random.value <= 0.25f && i != randomObstaclePosition && i != randomObstaclePosition2 && i != randomChestPosition) 
            {
                randomPrefab = decorationPrefabs[Random.Range(0, decorationPrefabs.Length)];
                Instantiate(randomPrefab, new Vector3(i, row + 1, row), randomPrefab.transform.rotation, decorations.transform);
                yield return new WaitForSeconds(tileWaitSeconds);
            }
        }
    }

    void CreateTop(int row)
    {
        //Instantiate one random obstacle at a random position
        int randomObstaclePosition = Random.Range(-3, 4);
        int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject randomPrefab = obstaclePrefabs[randomObstacleIndex];
        
        Instantiate(randomPrefab, new Vector3(randomObstaclePosition, row + 1, row), randomPrefab.transform.rotation, obstacles.transform);

        //If we are at an even row, instantiate a second obstacle at a random position
        int randomObstaclePosition2 = randomObstaclePosition;
        if (row % 2 == 0) 
        {
            int randomObstacleIndex2 = Random.Range(0, obstaclePrefabs.Length);
            randomPrefab = obstaclePrefabs[randomObstacleIndex2];
            
            //Ensure random position is not the same as the first obstacle
            while (randomObstaclePosition == randomObstaclePosition2)
            {
                randomObstaclePosition2 = Random.Range(-3, 4);

                //If the both obstacles are trees, don't instantiate 2 trees next to each other (because they clip)
                if ((randomObstacleIndex == 5 || randomObstacleIndex == 6) && (randomObstacleIndex2 == 5 || randomObstacleIndex2 == 6))
                {
                    if (randomObstaclePosition == randomObstaclePosition2 + 1 || randomObstaclePosition == randomObstaclePosition2 - 1)
                    {
                        //Set the second obstacle position to the same so the while loop executes again
                        randomObstaclePosition2 = randomObstaclePosition;
                    }
                }
            }

            Instantiate(randomPrefab, new Vector3(randomObstaclePosition2, row + 1, row), randomPrefab.transform.rotation, obstacles.transform);
        }

        //Instantiate a chest every 4 rows at a random position
        int randomChestPosition = randomObstaclePosition;
        if (row % 4 == 0) 
        {
            //Ensure it doesn't overlap obstacles
            while (randomChestPosition == randomObstaclePosition || randomChestPosition == randomObstaclePosition2)
            {
                randomChestPosition = Random.Range(-3, 4);
            }

            Instantiate(chestPrefab, new Vector3(randomChestPosition, row + 1, row), chestPrefab.transform.rotation, obstacles.transform);
        }

        //Instantiate a key every 4 rows (2 rows higher than chest) at a random position
        int randomKeyPosition = randomObstaclePosition;
        if (row % 4 == 2) 
        {
            //Ensure it doesn't overlap obstacles
            while (randomKeyPosition == randomObstaclePosition || randomKeyPosition == randomObstaclePosition2 || randomKeyPosition == randomChestPosition)
            {
                randomKeyPosition = Random.Range(-3, 4);
            }

            Instantiate(keyPrefab, new Vector3(randomKeyPosition, row + 1, row), keyPrefab.transform.rotation, obstacles.transform);
        }

        //Instantiate decorations with 25% chance every tile, not overlapping any other object.
        for (int i = -3; i <= 3; i++)
        {
            if (Random.value <= 0.25f && i != randomObstaclePosition && i != randomObstaclePosition2 && i != randomChestPosition) 
            {
                randomPrefab = decorationPrefabs[Random.Range(0, decorationPrefabs.Length)];
                Instantiate(randomPrefab, new Vector3(i, row + 1, row), randomPrefab.transform.rotation, decorations.transform);
            }
        }
    }

    void Update()
    {
        if (Camera.main.transform.position.y > floorHeight + 2)
        {
            floorHeight++;
            CreateNewRowOfTiles(floorHeight);
            if (floorHeight % 5 == 0)
            {
                CreateEnemyRow(floorHeight);
            }
            else
            {
                CreateTop(floorHeight);
            }
            //DeleteOldRowOfTiles();
        }
    }

    void CreateNewRowOfTiles(int height) 
    {
        GameObject randomPrefab = groundPrefabs[Random.Range(0, groundPrefabs.Length)];

        for (int i = -3; i <= 3; i++) 
        {
            Instantiate(randomPrefab, new Vector3(i, height, height), randomPrefab.transform.rotation, groundTiles.transform);
        }
    }

    void CreateNewRowOfTilesOneByOne(int height) 
    {
        GameObject randomPrefab = groundPrefabs[Random.Range(0, groundPrefabs.Length)];

        StartCoroutine(InstantiateTilePrefab(randomPrefab, height));
    }

    IEnumerator InstantiateTilePrefab(GameObject prefab, int height)
    {
        for (int i = -3; i <= 3; i++) 
        {
            Instantiate(prefab, new Vector3(i, height, height), prefab.transform.rotation, groundTiles.transform);
            yield return new WaitForSeconds(tileWaitSeconds);
        }

    }

    void CreateDecorations(int row) 
    {
        for (int i = -3; i <= 3; i++)
        {
            if (Random.value <= 0.25f) 
            {
                GameObject randomPrefab = decorationPrefabs[Random.Range(0, decorationPrefabs.Length)];
                Instantiate(randomPrefab, new Vector3(i, row + 1, row), randomPrefab.transform.rotation, decorations.transform);
            }
        }
    }

    IEnumerator CreateDecorationsOneByOne(int row) 
    {
        for (int i = -3; i <= 3; i++)
        {
            if (Random.value <= 0.25f) 
            {
                GameObject randomPrefab = decorationPrefabs[Random.Range(0, decorationPrefabs.Length)];
                Instantiate(randomPrefab, new Vector3(i, row + 1, row), randomPrefab.transform.rotation, decorations.transform);
            }
            yield return new WaitForSeconds(tileWaitSeconds);
        }
    }

    void DeleteOldRowOfTiles()
    {
        for (int i = 0; i <= 6; i++)
        {
            Object.Destroy(groundTiles.transform.GetChild(i).gameObject);
        }
    }

    void CreateEnemyRow(int height) 
    {
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(enemyPrefab, new Vector3(-11f, height + 1.56f, height - 0.23f), enemyPrefab.transform.rotation, enemies.transform);

        CreateDecorations(height);
    }

    //TODO: Icon
}
