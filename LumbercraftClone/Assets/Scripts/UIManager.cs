using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int wood;
    private int gold;
    [SerializeField] Text woodAmountText;
    [SerializeField] Text goldAmountText;

    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddWood(int amount)
    {
        wood += amount;
        woodAmountText.text = wood.ToString();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        goldAmountText.text = gold.ToString();
    }

    public int GetWoodAmount()
    {
        return wood;
    }
}
