using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(player.transform.position.x >= -14)
        {
            transform.position = new Vector3(player.transform.position.x + 10, player.transform.position.y + 2f, -10);
        }
    }
}
