using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldMakerManager : MonoBehaviour
{
    UIManager uiManager;
    public GameObject gmUI;

    public Text button1Text;
    public Text button2Text;
    public Text button3Text;

    int rate1;
    int rate2;
    int rate3;

    int woodAmount1;
    int woodAmount2;
    int woodAmount3;

    int goldAmount1;
    int goldAmount2;
    int goldAmount3;

    private void Start()
    {
        uiManager = UIManager.instance;
        StartCoroutine(GiveOffer1());
        StartCoroutine(GiveOffer2());
        StartCoroutine(GiveOffer3());
    }

    public void Offer1()
    {
        if (uiManager.GetWoodAmount() < woodAmount1)
        {
            Debug.Log("Not enough wood");
            return;
        }
        uiManager.AddWood(-woodAmount1);
        uiManager.AddGold(goldAmount1);
    }

    public void Offer2()
    {
        if (uiManager.GetWoodAmount() < woodAmount2)
        {
            Debug.Log("Not enough wood");
            return;
        }
        uiManager.AddWood(-woodAmount2);
        uiManager.AddGold(goldAmount2);
    }

    public void Offer3()
    {
        if (uiManager.GetWoodAmount() < woodAmount3)
        {
            Debug.Log("Not enough wood");
            return;
        }
        uiManager.AddWood(-woodAmount3);
        uiManager.AddGold(goldAmount3);
    }

    IEnumerator GiveOffer1()
    {
        rate1 = Random.Range(1, 3);
        woodAmount1 = Random.Range(100, 200);
        goldAmount1 = woodAmount1 * rate1;
        button1Text.text = woodAmount1 + " Wood to " + goldAmount1 + " Gold";
        yield return new WaitForSeconds(10);
        StartCoroutine(GiveOffer1());
    }

    IEnumerator GiveOffer2()
    {
        rate2 = Random.Range(1, 5);
        woodAmount2 = Random.Range(100, 200);
        goldAmount2 = woodAmount2 * rate2;
        button2Text.text = woodAmount2 + " Wood to " + goldAmount2 + " Gold";
        yield return new WaitForSeconds(10);
        StartCoroutine(GiveOffer2());
    }

    IEnumerator GiveOffer3()
    {
        rate3 = Random.Range(1, 6);
        woodAmount3 = Random.Range(100, 200);
        goldAmount3 = woodAmount3 * rate3;
        button3Text.text = woodAmount3 + " Wood to " + goldAmount3 + " Gold";
        yield return new WaitForSeconds(10);
        StartCoroutine(GiveOffer3());
    }
}
