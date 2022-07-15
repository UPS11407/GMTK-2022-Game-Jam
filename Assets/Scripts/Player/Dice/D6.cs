using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D6 : PlayerBase
{
    void Start()
    {
        
    }

    void Update()
    {
        Move(GetRigid());

        if (CheckIfGrounded()) {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                yump(GetRigid());
            }
        }
    }

    bool CheckIfGrounded()
    {
        float groundDistance = GetComponent<PolygonCollider2D>().bounds.extents.y;

        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, -Vector2.up, groundDistance + 0.05f, layerMask: _groundLayer.value);

        if (rayHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}