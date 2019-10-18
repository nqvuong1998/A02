using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    private float leftSceneX;
    private float rightSceneX;

    void Start()
    {
        leftSceneX = GameObject.Find("LeftScene").transform.position.x - 2;
        rightSceneX = GameObject.Find("RightScene").transform.position.x + 2;

        Vector3 temp = transform.position;
        temp.x = leftSceneX;
        transform.position = temp;

        playerTransform = GameObject.Find("Mario").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;

        float playerX = playerTransform.position.x;
        float playerY = playerTransform.position.y;
        if (playerX > leftSceneX && playerX < rightSceneX)
        {
            temp.x = playerX;
        }
        temp.y = playerY;
        temp.y += 3.1f;

        transform.position = temp;
    }
}
