using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObstaclesManager : MonoBehaviour
{
    public Text ObstacleValue;

    private readonly List<Obstacle> _obstaclesInGame = new List<Obstacle>();

    void Start()
    {
        foreach (var obstacle in FindObjectsOfType<Obstacle>())
        {
             _obstaclesInGame.Add(obstacle);
        }

        ObstacleValue.text = _obstaclesInGame.Count.ToString();
    }

    public void RemoveObstacle(Obstacle obstacle)
    {
        _obstaclesInGame.Remove(obstacle);
       
    }

    public void UpdateObstacleValue()
    {
        ObstacleValue.text = _obstaclesInGame.Count.ToString();
    }

}
