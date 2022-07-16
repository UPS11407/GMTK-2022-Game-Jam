using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    public enum type{
        D4,
        D6,
        D8,
        D10
    }

    public type _diceType = new type();
    public Sprite[] _diceSprites;

    private SpriteRenderer _renderer;
    private PolygonCollider2D[] colliders;
    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        colliders = GetComponents<PolygonCollider2D>();

        foreach(PolygonCollider2D collider in colliders)
        {
            collider.enabled = false;
        }
        SwitchDice();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchDice();
        }
    }

    void SwitchDice()
    {
        DisableAll();

        switch (_diceType)
        {
            case type.D4:
                Debug.Log("Switching to D6");
                GetComponent<D6>().enabled = true;
                _diceType = type.D6;

                _renderer.sprite = _diceSprites[1];
                colliders[1].enabled = true;

                transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                break;
            case type.D6:
                Debug.Log("Switching to D8");
                GetComponent<D8>().enabled = true;
                _diceType = type.D8;

                _renderer.sprite = _diceSprites[2];
                colliders[2].enabled = true;
                
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                rigid.gravityScale = 8;
                break;
            case type.D8:
                Debug.Log("Switching to D10");
                GetComponent<D10>().enabled = true;
                _diceType = type.D10;

                _renderer.sprite = _diceSprites[3];
                colliders[3].enabled = true;

                transform.localScale = new Vector3(0.82f, 0.82f, 0.82f);
                rigid.gravityScale = 7;
                break;
            case type.D10:
                Debug.Log("Switching to D4");
                GetComponent<D4>().enabled = true;
                _diceType = type.D4;

                _renderer.sprite = _diceSprites[0];
                colliders[0].enabled = true;

                transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                rigid.gravityScale = 7;
                break;
            default:
                Debug.LogError("No dice selected during switch");
                break;
        }
    }

    void DisableAll()
    {
        foreach (PolygonCollider2D collider in colliders)
        {
            collider.enabled = false;
        }

        GetComponent<D4>().enabled = false;
        GetComponent<D6>().enabled = false;
        GetComponent<D8>().enabled = false;
        GetComponent<D10>().enabled = false;
    }
}