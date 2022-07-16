using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D8 : PlayerBase
{
    private bool inverted = false;

    private void Start()
    {
        GetRigid().gravityScale = 8;
    }

    void Update()
    {
        Move(GetRigid());

        if (Input.GetKeyDown(KeyCode.X))
        {
            invert();
        }

        if (CheckIfGrounded())
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                D8yump();
            }
        }
    }

    void invert()
    {
        GetRigid().gravityScale *= -1;
    }

    void D8yump()
    {
        if (inverted)
        {
            GetRigid().velocity = new Vector2(0, -1) * _jumpForce;
        }
        else
        {
            GetRigid().velocity = new Vector2(0, 1) * _jumpForce;
        }
    }

    bool CheckIfGrounded()
    {
        float groundDistance = GetComponent<PolygonCollider2D>().bounds.extents.y;
        float xOffset = GetComponent<PolygonCollider2D>().bounds.extents.x;
        RaycastHit2D rayHit;

        if (!inverted)
        {
            rayHit = Physics2D.Raycast(new Vector2(transform.position.x - xOffset, transform.position.y), -Vector2.up, groundDistance + 0.05f, layerMask: _groundLayer.value);
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
        else
        {
            rayHit = Physics2D.Raycast(new Vector2(transform.position.x - xOffset, transform.position.y), Vector2.up, groundDistance + 0.05f, layerMask: _groundLayer.value);
            if (rayHit.collider != null)
            {
                return true;
            }
            else
            {
                rayHit = Physics2D.Raycast(new Vector2(transform.position.x + xOffset, transform.position.y), Vector2.up, groundDistance + 0.05f, layerMask: _groundLayer.value);

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