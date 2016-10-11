using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public int Level { get; set; }

    public GameObject NextLevelPrefab;
    public GameObject[] Obstacles;

    private int _spawnObstaclesCount;
    private CanvasTextManager _canvasTextManager;

    void Start()
    {
        _canvasTextManager = GameObject.FindObjectOfType<CanvasTextManager>();
        _canvasTextManager.LevelText.text = Level.ToString();
    }

    public void ProgressToNextLevel()
    {
        GameObject nextLevelPrefab = Instantiate(NextLevelPrefab, transform.position, Quaternion.identity) as GameObject;
        if (nextLevelPrefab == null)
            return;

        Level++;
        _canvasTextManager.UpdateCanvasTextValue(_canvasTextManager.LevelText, Level.ToString());
    }

    public void GenerateNewLevel()
    {
        float minPos = -2;          // Limit the spawn space. Will be replaced with prefab.
        float maxPos = 2;
        float detectDistance = 2.4f;  // The distance between the closest rock.

        foreach (var obs in FindObjectsOfType<Obstacle>())      // Finds if there's any left over obstacles, destroys them if so.
        {
            if (obs == null)
                return;
            Destroy(obs.gameObject);
        }

        List<Vector2> positionBuffer = new List<Vector2>();     // For storing the set positions.

        for (int i = 1; i <= _spawnObstaclesCount; i++)
        {
            Vector2 newRandomPosition = new Vector2(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos));
            positionBuffer.Add(newRandomPosition);

        }
        // Still broken......
        for (int i = 0; i < positionBuffer.Count; i++)
        {
            if (positionBuffer[i] != positionBuffer[positionBuffer.Count - 1])      // if the loop has reached to the end of the List size.
            {
                Vector2 offset = positionBuffer[i] - positionBuffer[i + 1];
                float sqrLen = offset.sqrMagnitude;

                if (sqrLen < Mathf.Pow(detectDistance, 2))
                {
                    positionBuffer.Remove(positionBuffer[i]);

                    Vector2 newRandomPosition = new Vector2(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos));
                    positionBuffer.Add(newRandomPosition);
                }
            }
        }

        foreach (var obstaclePosition in positionBuffer)
        {
            int randomObstacle = Random.Range(0, Obstacles.Length);     // Choose random obstacle from the Obstacles array.
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

            GameObject obstaclePrefab = Instantiate(Obstacles[randomObstacle],
                this.transform.position, randomRotation) as GameObject;

            if (obstaclePrefab == null)
                return;

            obstaclePrefab.transform.SetParent(GameObject.FindGameObjectWithTag("WorldObjects").transform);
            obstaclePrefab.transform.position = obstaclePosition;
        }

        positionBuffer.Clear(); // Clear the buffer.
    }

    public void SetObstaclesSpawnCount(int spawnCount)
    {
        _spawnObstaclesCount = spawnCount;
    }
}
