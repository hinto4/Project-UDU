﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public abstract class Obstacle : MonoBehaviour
{
    public float Health = 100f;
    public int GivePointsForDestroying = 1;                     // default is 1

    public GameObject BonusItemPrefab;

    private Ball _playerBall;
    private PointsManager _pointsManager;

    private readonly List<DestructionSystem> _childObjects = new List<DestructionSystem>();

    void Start()
    {
        _playerBall = GameObject.FindObjectOfType<Ball>();
        _pointsManager = GameObject.FindObjectOfType<PointsManager>();

        foreach (var obj in this.GetComponentsInChildren<DestructionSystem>())
        {
            _childObjects.Add(obj);
        }

        _pointsManager.UpdateObstacleList(this);
    }

    void Update()
    {
        ScanHealth();
    }
    
    // TEMP CODE, TESTING PUPORSE
    public void RemoveItemFromChildObjectsList(DestructionSystem childObject)
    {
        _childObjects.Remove(childObject);
    }

    public void SpawnBonusItem()
    {
        Instantiate(BonusItemPrefab, this.transform.position, Quaternion.identity);
    }

    void ScanHealth()
    {
        //if (Health <= 0)      Currently not needed, as working on new destruction system.
        //{
        //    if (this.gameObject == null)
        //        return;

        //    _pointsManager.RemoveObstacle(this.gameObject.GetComponent<Obstacle>());
        //    _pointsManager.UpdatePointsValue(GivePointsForDestroying);
        //    SpawnBonusItem();

        //    GameObject.DestroyObject(this.gameObject);
        //}

        if(_childObjects.Count <= 0)
        {
            _pointsManager.RemoveObstacle(this.gameObject.GetComponent<Obstacle>());
            SpawnBonusItem();
            Destroy(this);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(_playerBall == null)
            return;

        if (col.gameObject == _playerBall.gameObject)
        {
            Health -= _playerBall.Damage;
        }
    }
}
