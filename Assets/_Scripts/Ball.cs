using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
    public int MaxDamage = 100;
    public int MinDamage = 10;
    public int Damage;
    public GameObject DamageIndicatorPrefab;

    //
    private BonusManager _bonusManager;

    void Start()
    {
        _bonusManager = GameObject.FindObjectOfType<BonusManager>();
    }

    void Update()
    {
        DamageManager();
    }

    void DamageManager()
    {
        Damage = Random.Range(MinDamage, MaxDamage);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Obstacle>())
        {
            ShowDamagePopUp();
        }

        if (col.gameObject.GetComponent<Bonus>())
        {
            _bonusManager.Bonus += 20;              // TODO will be changed, bonus value depends on the value and type of the picked up bonus.
            _bonusManager.UpdateBonusValue();
            _bonusManager.RemoveBonusItem(col.gameObject.GetComponent<Bonus>());
        }
    }

    void ShowDamagePopUp()
    {
        GameObject damageIndicator = Instantiate(DamageIndicatorPrefab, this.transform.position, Quaternion.identity) as GameObject;
        if (damageIndicator == null)
            return;

        if (Damage > MaxDamage - 10)                                        // TODO replace this ugly magic shit... Check for percent of the damage to max damage.
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
}
