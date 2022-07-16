using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D6 : PlayerBase
{
    private void Start()
    {
        GetRigid().gravityScale = 7;
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
        float xOffset = GetComponent<PolygonCollider2D>().bounds.extents.x;

        RaycastHit2D rayHit = Physics2D.Raycast(new Vector2(transform.position.x - xOffset, transform.position.y), -Vector2.up, groundDistance + 0.05f, layerMask: _groundLayer.value);

        if (rayHit.collider != null)
        {
            return true;
        }
        else
        {
            rayHit = Physics2D.Raycast(new Vector2(transform.position.x + xOffset, transform.position.y), -Vector2.up, groundDistance + 0.05f, layerMask: _groundLayer.value);

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
}