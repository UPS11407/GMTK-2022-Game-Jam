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
        if(player.transform.position.x > -14)
        {
            transform.position = new Vector3(player.transform.position.x + 13, player.transform.position.y - 1.75f, -10);
        }

        if(player.transform.position.y > 4.75f)
        {
            //transform.position = new Vector3(player.transform.position.x + 13, player.transform.position.y - 4.75f, -10);
        }
    }
}
