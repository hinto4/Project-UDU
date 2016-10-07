using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BonusManager : MonoBehaviour
{
    public Text BonusValue;

    private int _bonus;

    private readonly List<Bonus> _bonusesInGame = new List<Bonus>();

    void Start()
    {
        foreach (var bonus in FindObjectsOfType<Bonus>())
        {
            _bonusesInGame.Add(bonus);
        }
    }
    
    public void UpdateBonusValue(int value)
    {
        _bonus = value;
        UpdateBonusCanvas();
    }

    public void RemoveBonusItem(Bonus bonus)
    {
        _bonusesInGame.Remove(bonus);
    }

    private void UpdateBonusCanvas()
    {
        BonusValue.text = _bonus.ToString();
    }

}
