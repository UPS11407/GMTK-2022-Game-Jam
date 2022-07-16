using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private GlobalController _controller;

    void Start()
    {
        _controller = GameObject.Find("Controller").GetComponent<GlobalController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            _controller.AddCoin(1);

            Destroy(gameObject);
        }
    }
}
