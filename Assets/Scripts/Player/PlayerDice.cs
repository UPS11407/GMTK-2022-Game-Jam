using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    public enum type{
        D4,
        D6,
        D8,
        D10,
        D100
    }

    public type _diceType = new type();
    public Sprite[] _diceSprites;

    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        switch (_diceType)
        {
            case type.D4:
                Debug.Log("D4");
                GetComponent<D4>().enabled = true;
                break;
            case type.D6:
                Debug.Log("D6");
                GetComponent<D6>().enabled = true;
                break;
            case type.D8:
                Debug.Log("D8");
                GetComponent<D8>().enabled = true;
                break;
            case type.D10:
                Debug.Log("D10");
                GetComponent<D10>().enabled = true;
                break;
            case type.D100:
                Debug.Log("D100");
                break;
            default:
                Debug.LogError("No dice selected");
                break;
        }
    }
}