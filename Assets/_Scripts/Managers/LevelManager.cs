using UnityEngine;
using System.Collections;

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
        //TEMP CODE For generation debugger

        foreach (var obs in FindObjectsOfType<Obstacle>())
        {
            if (obs == null)
                return;
            Destroy(obs.gameObject);
        }

        float minPos = -2;
        float maxPos = 2;

        for (int i = 1; i <= _spawnObstaclesCount; i++)
        {
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            Vector2 newRandomPosition = new Vector2(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos));
            int randomObstacle = Random.Range(0, Obstacles.Length);

            GameObject obstaclePrefab = Instantiate(Obstacles[randomObstacle], this.transform.position, randomRotation) as GameObject;

            if (obstaclePrefab == null)
                return;

            obstaclePrefab.transform.SetParent(GameObject.FindGameObjectWithTag("WorldObjects").transform);
            obstaclePrefab.transform.position = newRandomPosition;
        }
    }

    public void SetObstaclesSpawnCount(int spawnCount)
    {
        _spawnObstaclesCount = spawnCount;
    }
}
