using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 lastTapPos;
    UIManager uiManager;
    Rigidbody playerRb;
    float _speed = 2f;

    [SerializeField] private float dragSpeed = 5f;

    float deltaX = 0;
    float deltaY = 0;

    private void Start()
    {
        uiManager = UIManager.instance;
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //DragHandler();
    }

    private void FixedUpdate()
    {
        KeyboardMove();
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

    void KeyboardMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //playerRb.velocity = Vector3.forward.normalized * _speed * Time.fixedDeltaTime * 20;
        Vector3 move = new Vector3(horizontal, 0, vertical);
        playerRb.velocity = move * _speed * Time.fixedDeltaTime * 300;
    }
}
