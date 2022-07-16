using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaRaise : MonoBehaviour
{
    public float _top;
    public float _speed;

    void FixedUpdate()
    {
        if(transform.position.y + GetComponent<Collider2D>().bounds.extents.y < _top)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + _speed, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<PlayerBase>().ResetLevel(SceneManager.GetSceneByName(GameObject.Find("Controller").GetComponent<GlobalController>()._mainLevelScene));
        }
    }
}
