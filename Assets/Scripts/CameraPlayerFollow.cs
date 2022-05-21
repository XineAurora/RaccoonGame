using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        var playerPos = player.transform.position;
        playerPos.z = -10;
        transform.position = Vector3.Lerp(transform.position, playerPos, 0.9f);
    }
}
