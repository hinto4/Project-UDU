using UnityEngine;
using System.Collections;

public abstract class Bonus : MonoBehaviour
{
    public int AliveTime = 5;

    private Ball _playerBall;
    private TextMesh _countDownTimerText;
    private float _countDownTimer;

    void Start()
    {
        _playerBall = GameObject.FindObjectOfType<Ball>();
        _countDownTimerText = GetComponentInChildren<TextMesh>();
        _countDownTimer = Time.time + AliveTime;
    }

    void Update()
    {
        PickUpCounter();
        UpdateTimerText();
    }

    void PickUpCounter()
    {
        if (_countDownTimer - Time.time <= 0)
        {
            DestroyObject(this.gameObject);
        }
    }

    void UpdateTimerText()
    {
        int timer = Mathf.RoundToInt(_countDownTimer - Time.time);
        _countDownTimerText.text = timer.ToString();

    }

    void CalcPointsBonus()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == _playerBall.gameObject)
        {
            CalcPointsBonus();
        }
    }
}
