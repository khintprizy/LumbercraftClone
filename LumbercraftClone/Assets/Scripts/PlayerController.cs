using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 lastTapPos;
    UIManager uiManager;

    [SerializeField] private float dragSpeed = 5f;

    float deltaX = 0;
    float deltaY = 0;

    private void Start()
    {
        uiManager = UIManager.instance;
    }

    private void Update()
    {
        DragHandler();
    }

    void DragHandler()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
            {
                lastTapPos = currentTapPos;
            }

            float tapPosX = currentTapPos.x;
            float tapPosY = currentTapPos.y;

            float halfWidth = Screen.width / 2;
            float halfHeight = Screen.height / 2;


            deltaX = (halfWidth - tapPosX)/100;
            deltaY = (halfHeight - tapPosY)/50;


            lastTapPos = currentTapPos;

            transform.Translate(Vector3.left.normalized * dragSpeed * deltaX * Time.deltaTime);
            transform.Translate(Vector3.forward.normalized * -dragSpeed * deltaY * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }
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
