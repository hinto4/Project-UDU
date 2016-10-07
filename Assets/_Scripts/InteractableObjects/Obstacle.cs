using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public abstract class Obstacle : MonoBehaviour
{
    public float Health = 100f;

    public GameObject BonusItemPrefab;

    private Ball _playerBall;
    private PointsManager _pointsManager;

    void Start()
    {
        _playerBall = GameObject.FindObjectOfType<Ball>();
        _pointsManager = GameObject.FindObjectOfType<PointsManager>();
    }

    void Update()
    {
        ScanHealth();
    }

    void ScanHealth()
    {
        if (Health <= 0)
        {
            if (this.gameObject == null)
                return;

            _pointsManager.RemoveObstacle(this.gameObject.GetComponent<Obstacle>());
            _pointsManager.UpdatePointsValue();
            SpawnBonusItem();

            GameObject.DestroyObject(this.gameObject);
        }
    }

    void SpawnBonusItem()
    {
        Instantiate(BonusItemPrefab, this.transform.position, Quaternion.identity);
    }

   void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == _playerBall.gameObject)
        {
            Health -= _playerBall.Damage;
        }
    }
}
