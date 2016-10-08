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
        foreach (var obstacle in FindObjectsOfType<Obstacle>())
        {
             _obstaclesInGame.Add(obstacle);
        }

        _canvasTextManager = GameObject.FindObjectOfType<CanvasTextManager>();
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

    private void UpdatePointsCanvas()   
    {
        _canvasTextManager.PointsValueText.text = _collectedPoints.ToString();
    }
}
