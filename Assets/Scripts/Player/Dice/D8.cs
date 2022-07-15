using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D8 : PlayerBase
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
        //get collider values or make an extra collider for the smaller version, not sure yet how to fully know which one is which.
        if (!small)
        {
            transform.localScale = transform.localScale / 2f;
            small = true;
        }
        else
        {
            transform.localScale = transform.localScale * 2f;
            small = false;
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