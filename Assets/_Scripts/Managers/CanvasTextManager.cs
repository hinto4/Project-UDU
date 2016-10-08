using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasTextManager : MonoBehaviour
{
    public Text PointsValueText;
    public Text NeededPointsText;
    public Text LevelText;

    public void UpdateCanvasTextValue(Text textType, string message)
    {
        textType.text = message;
    }
}
