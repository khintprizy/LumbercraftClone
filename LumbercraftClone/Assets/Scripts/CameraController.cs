using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 offset;
    [SerializeField] GameObject player;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        //transform.position = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.2f);
    }

}
