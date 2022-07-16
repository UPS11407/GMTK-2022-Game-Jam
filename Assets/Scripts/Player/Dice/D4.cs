using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D4 : PlayerBase
{
    private int jumpCount = 0;

    void Start()
    {

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
        int index = 0;
        for (int i = 0; i < GetComponents<PolygonCollider2D>().Length; i++)
        {
            if (GetComponents<PolygonCollider2D>()[i].enabled == true)
            {
                index = i;
            }
        }

        float groundDistance = GetComponents<PolygonCollider2D>()[index].bounds.extents.y;
        float xOffset = GetComponents<PolygonCollider2D>()[index].bounds.extents.x;

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
                rayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.up, groundDistance + 0.05f, layerMask: _groundLayer.value);

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
}