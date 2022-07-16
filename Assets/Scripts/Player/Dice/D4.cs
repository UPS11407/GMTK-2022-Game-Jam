using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D4 : PlayerBase
{
    private int jumpCount = 0;

    void Start()
    {
        GetRigid().gravityScale = 7;
    }

    void Update()
    {
        Move(GetRigid());

        if (CheckIfGrounded() || jumpCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                jumpCount -= 1;
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
            jumpCount = 2;
            return true;
        }
        else
        {
            rayHit = Physics2D.Raycast(new Vector2(transform.position.x + xOffset, transform.position.y), -Vector2.up, groundDistance + 0.05f, layerMask: _groundLayer.value);

            if (rayHit.collider != null)
            {
                jumpCount = 2;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}