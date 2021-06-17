using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.instance;
        uiManager.AddWood(1000);
    }
}
