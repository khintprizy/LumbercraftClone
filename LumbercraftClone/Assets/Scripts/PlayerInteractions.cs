using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.lumberMillTriggerTag))
        {
            LumberMillManager lmManager = other.transform.parent.GetComponent<LumberMillManager>();
            uiManager.AddWood(lmManager.stackedWood);
            lmManager.StackWood(-lmManager.stackedWood);
            lmManager.lmUI.SetActive(true);
        }
        if (other.gameObject.CompareTag(Tags.goldMakerTriggerTag))
        {
            GoldMakerManager gmManager = other.transform.parent.GetComponent<GoldMakerManager>();
            gmManager.gmUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.lumberMillTriggerTag))
        {
            LumberMillManager lmManager = other.transform.parent.GetComponent<LumberMillManager>();
            lmManager.lmUI.SetActive(false);
        }
        if (other.gameObject.CompareTag(Tags.goldMakerTriggerTag))
        {
            GoldMakerManager gmManager = other.transform.parent.GetComponent<GoldMakerManager>();
            gmManager.gmUI.SetActive(false);
        }
    }
}
