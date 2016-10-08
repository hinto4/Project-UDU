using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public int Level { get; set; }

    private CanvasTextManager _canvasTextManager;

    void Start()
    {
        _canvasTextManager = GameObject.FindObjectOfType<CanvasTextManager>();
        _canvasTextManager.LevelText.text = Level.ToString();
    }

    public void ProgressToNextLevel()
    {
        Level++;
        _canvasTextManager.UpdateCanvasTextValue(_canvasTextManager.LevelText, Level.ToString());
    }
}
