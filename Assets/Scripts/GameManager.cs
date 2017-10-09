using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Editor Side Dependency Injection
    public Ship shipPrefab;

    private Ship PlayerShip { get; set; }

    private void Start ()
    {
        PlayerShip = Instantiate(shipPrefab);
	}


    private void ReadKeyboardInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerShip.ThurstForward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerShip.TurnLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerShip.TurnRight();
        }
    }

    private void ReadControllerInput()
    {
        if (Input.GetButton("Fire2"))
        {
            PlayerShip.ThurstForward();
        }
        if (Input.GetButton("Left"))
        {
            PlayerShip.TurnLeft();
        }
        if (Input.GetButton("Right"))
        {
            PlayerShip.TurnRight();
        }
    }


    private void FixedUpdate ()
    {
        ReadKeyboardInput();
        ReadControllerInput();
    }
}
