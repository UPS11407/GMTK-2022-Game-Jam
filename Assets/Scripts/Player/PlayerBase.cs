using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float _speed = 5f;
    public float _jumpForce = 25f;

    public LayerMask _groundLayer;

    public Rigidbody2D GetRigid()
    {
        return GetComponent<Rigidbody2D>();
    }

    public void Move(Rigidbody2D rigid)
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(transform.right.x * _speed, rigid.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(-transform.right.x * _speed, rigid.velocity.y);
        }
        else
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
    }

    public void yump(Rigidbody2D rigid)
    {
        rigid.velocity = new Vector2(0, 1) * _jumpForce;
    }
}