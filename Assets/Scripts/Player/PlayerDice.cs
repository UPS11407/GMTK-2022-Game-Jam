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

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
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
                break;
            case type.D6:
                Debug.Log("Switching to D8");
                GetComponent<D8>().enabled = true;
                _diceType = type.D8;
                break;
            case type.D8:
                Debug.Log("Switching to D10");
                GetComponent<D10>().enabled = true;
                _diceType = type.D10;
                break;
            case type.D10:
                Debug.Log("Switching to D4");
                GetComponent<D4>().enabled = true;
                _diceType = type.D4;
                break;
            default:
                Debug.LogError("No dice selected during switch");
                break;
        }
    }

    void DisableAll()
    {
        GetComponent<D4>().enabled = false;
        GetComponent<D6>().enabled = false;
        GetComponent<D8>().enabled = false;
        GetComponent<D10>().enabled = false;
    }
}