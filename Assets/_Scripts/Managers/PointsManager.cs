using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    private int _collectedPoints;

    public int CollectedPoints
    {
        get { return _collectedPoints; }
    }

    private readonly List<Obstacle> _obstaclesInGame = new List<Obstacle>();

    private CanvasTextManager _canvasTextManager;

    void Start()
    {
        _canvasTextManager = GameObject.FindObjectOfType<CanvasTextManager>();
    }

    public int ObstacleCount()
    {
        return _obstaclesInGame.Count;
    }

    public void UpdateObstacleList(Obstacle addObstacle)
    {
        _obstaclesInGame.Add(addObstacle);
    }

    public void RemoveObstacle(Obstacle obstacle)
    {
        _obstaclesInGame.Remove(obstacle);
    }

    public void UpdatePointsValue(int value)
    {
        _collectedPoints += value;
        UpdatePointsCanvas();
    }

    public void ResetPoints()
    {
        _collectedPoints = 0;
        UpdatePointsCanvas();
    }

    private void UpdatePointsCanvas()   
    {
        _canvasTextManager.PointsValueText.text = _collectedPoints.ToString();
    }
}
