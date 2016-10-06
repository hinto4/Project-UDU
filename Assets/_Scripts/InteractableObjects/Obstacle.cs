using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public abstract class Obstacle : MonoBehaviour
{
    public float Health = 100f;

    private float _damage;
    private Ball _playerBall;
    private ObstaclesManager _obstaclesManager;

    void Start()
    {
        _playerBall = GameObject.FindObjectOfType<Ball>();
        _obstaclesManager = GameObject.FindObjectOfType<ObstaclesManager>();
    }

    void Update()
    {
        if (Health <= 0)
        {
            _obstaclesManager.RemoveObstacle(this.gameObject.GetComponent<Obstacle>());
            _obstaclesManager.UpdateObstacleValue();
            GameObject.DestroyObject(this.gameObject);
        }
    }

   void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == _playerBall.gameObject)
        {
            _damage = _playerBall.Damage;
            Debug.Log(_damage);
            Health -= _damage;
        }
    }
}
