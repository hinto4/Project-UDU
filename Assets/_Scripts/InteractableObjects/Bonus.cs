using UnityEngine;
using System.Collections;

public abstract class Bonus : MonoBehaviour
{
    private Ball _playerBall;

    void Start()
    {
        _playerBall = GameObject.FindObjectOfType<Ball>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == _playerBall.gameObject)
        {
            DestroyObject(this.gameObject);
        }
    }
}
