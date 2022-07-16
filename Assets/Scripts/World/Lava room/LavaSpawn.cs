using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpawn : MonoBehaviour
{
    public Transform _spawnPoint;
    public GameObject _lavaPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Instantiate(_lavaPrefab, _spawnPoint);
        }
    }
}
