using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PointsManager), typeof(LevelManager))]
public class GameManager : MonoBehaviour
{
    [Tooltip("Set the points that are needed for player to progress to the next level.")]
    public int NeededPoints = 10;               // Default 40: Points needed to collect for level to finish.

    private PointsManager _pointsManager;
    private CanvasTextManager _canvasTextManager;
    private LevelManager _levelManager;

    private bool levelProgressed;

    void Start()
    {
        _pointsManager = GameObject.FindObjectOfType<PointsManager>();
        _canvasTextManager = GameObject.FindObjectOfType<CanvasTextManager>();
        _levelManager = GameObject.FindObjectOfType<LevelManager>();

        _canvasTextManager.NeededPointsText.text = NeededPoints.ToString();
    }

    void Update()
    {
        TrackCollectedPoints();
    }

    void TrackCollectedPoints()
    {
        if (_pointsManager.CollectedPoints >= NeededPoints)
        {
            // Enable level progression.
            if (!levelProgressed)
            {
                _levelManager.ProgressToNextLevel();
                levelProgressed = true;
            }
        }
    }
}
