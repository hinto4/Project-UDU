using System;
using UnityEngine;
using System.Collections;

public abstract class Bonus : MonoBehaviour
{
    public int AliveTime = 5;
    public int MaxPointsToGive = 5;

    private Ball _playerBall;
    private TextMesh _countDownTimerText;
    private float _countDownTimer;
    private PointsManager _pointsManager;

    void Start()
    {
        _playerBall = GameObject.FindObjectOfType<Ball>();
        _countDownTimerText = GetComponentInChildren<TextMesh>();
        _countDownTimer = Time.time + AliveTime;
        _pointsManager = FindObjectOfType<PointsManager>();

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200f);
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
        double remainingTime = Mathf.RoundToInt(_countDownTimer - Time.time);

        if (remainingTime < 0)
            return;

        double percentOfAliveTime = remainingTime / Convert.ToDouble(AliveTime);

        float calcPoints = Convert.ToSingle(percentOfAliveTime) * MaxPointsToGive;

        _pointsManager.UpdatePointsValue(Mathf.RoundToInt(calcPoints));
        _playerBall.ShowPlayerTextNotation("+" + calcPoints.ToString());

        DestroyObject(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (_playerBall == null)
            return;

        if (col.gameObject == _playerBall.gameObject)
        {
            CalcPointsBonus();
        }
    }
}
