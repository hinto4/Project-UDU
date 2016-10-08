using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public int Level { get; set; }

    public GameObject NextLevelPrefab;

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

        nextLevelPrefab.transform.SetParent(GameObject.FindObjectOfType<BoxMovementController>().transform);

        Level++;
        _canvasTextManager.UpdateCanvasTextValue(_canvasTextManager.LevelText, Level.ToString());
    }
}
