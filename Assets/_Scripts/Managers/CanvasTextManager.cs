using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasTextManager : MonoBehaviour
{
    public Text PointsValueText;
    public Text NeededPointsText;
    public Text LevelText;
    public Text AnnouncerText;

    private bool _fadeTextCalled;
    private float _startTimer;
    private Text _textBuffer;

    void Start()
    {
    }

    void Update()
    {
        if (_fadeTextCalled)
        {
            if (_startTimer - Time.time <= 0)
            {
                _textBuffer.text = "";
                _fadeTextCalled = false;
            }  
        }
    }

    public void UpdateCanvasTextValue(Text textType, string message)
    {
        textType.text = message;
    }

    public void FadeText(Text textType, float time)
    {
        _startTimer = Time.time + time;
        _textBuffer = textType;
        _fadeTextCalled = true;
    }
}
