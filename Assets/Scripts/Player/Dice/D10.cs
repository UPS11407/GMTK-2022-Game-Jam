using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D10 : PlayerBase
{
    private bool small = false;

    void Update()
    {
        Move(GetRigid());

        if (CheckIfGrounded())
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                yump(GetRigid());
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            shrink();
        }
    }

    void shrink()
    {
        if (!small)
        {
            transform.localScale = transform.localScale / 2f;
            GetRigid().gravityScale = 6;
            small = true;
        }
        else
        {
            transform.localScale = transform.localScale * 2f;
            GetRigid().gravityScale = 14;
            small = false;
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
                rayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.up, groundDistance + 0.05f, layerMask: _groundLayer.value);

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
}