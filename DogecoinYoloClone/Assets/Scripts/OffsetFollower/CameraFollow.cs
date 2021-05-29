using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private float offsetX;
    private float offsetY;


    private void Start()
    {
        offsetX = transform.position.x - player.transform.position.x;

        offsetY = transform.position.y - player.transform.position.y;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(offsetX,offsetY,transform.position.z);
    }
}
