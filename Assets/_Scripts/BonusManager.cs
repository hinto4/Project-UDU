using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BonusManager : MonoBehaviour
{
    public int Bonus;
    public Text BonusValue;

    private readonly List<Bonus> _bonusesInGame = new List<Bonus>();

    void Start()
    {
        foreach (var bonus in FindObjectsOfType<Bonus>())
        {
            _bonusesInGame.Add(bonus);
        }

        BonusValue.text = Bonus.ToString();
    }
    
    public void UpdateBonusValue()
    {
        BonusValue.text = Bonus.ToString();
    }

    public void RemoveBonusItem(Bonus bonus)
    {
        _bonusesInGame.Remove(bonus);
    }

}
