using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public int Damage { get; private set; }

    public GameObject DamageIndicatorPrefab;

    private BonusManager _bonusManager;

    private int MaxDamage = 50;
    private int MinDamage = 10;

    private Vector3 _previousPosition;

    void Start()
    {
        _bonusManager = GameObject.FindObjectOfType<BonusManager>();
        _previousPosition = transform.position;                     // Starting off last position as current position
    }

    void Update()   
    {
        DamageManager();
        CalcMovementFaceDirection();
    }

    void CalcMovementFaceDirection()       // TODO add Quaternion.Slerp for smooth rotation for the character between axis + speed controller.
    {
        //Debug.Log(this.GetComponent<Rigidbody2D>().velocity);
        //Debug.Log(transform.InverseTransformDirection(this.gameObject.GetComponent<Rigidbody2D>().velocity));
        Vector3 positionFor2D = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        Vector3 deltaPosition = positionFor2D - _previousPosition;  // Calculate position change between frames

        if (deltaPosition != Vector3.zero)
        {
            transform.up = deltaPosition;                           // rotates Y axis as facing axis towards the movement.
        }

        _previousPosition = transform.position;                     // Recording current position as previous position for next frame
    }

    void DamageManager()                                            // Give random damage.
    {                                                               //TODO Adding feature, damage depends on the speed of the ball.
        Damage = Random.Range(MinDamage, MaxDamage);
    }

    void ShowDamagePopUp()
    {
        GameObject damageIndicator = Instantiate(DamageIndicatorPrefab, this.transform.position, Quaternion.identity) as GameObject;
        if (damageIndicator == null)
            return;

        if (Damage > MaxDamage - 10)                                        // TODO replace this ugly magic... Check for percent of the damage to max damage.
        {
            damageIndicator.GetComponent<TextMesh>().color = Color.red;
        }
        else if (Damage > MaxDamage - 20)
        {
            damageIndicator.GetComponent<TextMesh>().color = Color.green;
        }
        else if (Damage < MinDamage + 10)
        {
            damageIndicator.GetComponent<TextMesh>().color = Color.gray;
        }

        damageIndicator.GetComponent<TextMesh>().text = Damage.ToString();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Obstacle>())
        {
            ShowDamagePopUp();
        }

        //if (col.gameObject.GetComponent<Bonus>())
        //{                                                       // TODO make the bonus class work with this.
        //    _bonusManager.UpdateBonusValue(20);              // TODO will be changed, bonus value depends on the value and type of the picked up bonus.
        //    _bonusManager.RemoveBonusItem(col.gameObject.GetComponent<Bonus>());
        //}
    }
}
