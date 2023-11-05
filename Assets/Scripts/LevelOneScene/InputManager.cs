using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private KeyCode lastKeyPressed;

    public KeyCode LastKeyPressed { get { return lastKeyPressed; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lastKeyPressed = KeyCode.RightArrow;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lastKeyPressed = KeyCode.LeftArrow;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            lastKeyPressed = KeyCode.UpArrow;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lastKeyPressed = KeyCode.DownArrow;
        }
    }
}
