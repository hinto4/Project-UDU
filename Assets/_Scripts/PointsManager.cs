using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Text PointsValue;

    private int _collectedPoints;

    private readonly List<Obstacle> _obstaclesInGame = new List<Obstacle>();

    void Start()
    {
        foreach (var obstacle in FindObjectsOfType<Obstacle>())
        {
             _obstaclesInGame.Add(obstacle);
        }
    }

    public void RemoveObstacle(Obstacle obstacle)
    {
        _obstaclesInGame.Remove(obstacle);
    }

    public void UpdatePointsValue()
    {
        _collectedPoints++;
        UpdatePointsCanvas();   
    }

    private void UpdatePointsCanvas()   
    {
        PointsValue.text = _collectedPoints.ToString();
    }

}
