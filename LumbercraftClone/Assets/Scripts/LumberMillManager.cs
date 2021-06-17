using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LumberMillManager : MonoBehaviour
{
    UIManager uiManager;
    public GameObject lmUI;
    [SerializeField] Text woodPerMinText;
    [SerializeField] Text currentWoodAmountText;
    int woodPerSecond = 1;

    int _stackedWood;
    public int stackedWood
    {
        get
        {
            return _stackedWood;
        }
    }

    private void Start()
    {
        uiManager = UIManager.instance;
        StartCoroutine(ProduceWood());
        UpdateUI();
    }

    IEnumerator ProduceWood()
    {
        yield return new WaitForSeconds(1);
        StackWood(woodPerSecond);
        StartCoroutine(ProduceWood());
    }

    void UpdateUI()
    {
        woodPerMinText.text = (woodPerSecond * 60).ToString();
    }

    public void StackWood(int amount)
    {
        _stackedWood += amount;
        currentWoodAmountText.text = _stackedWood.ToString();
    }
}
