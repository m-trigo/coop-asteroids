using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Editor Side Dependency Injection
    public Ship shipPrefab;
    public Meteor meteorPrefab;

    private Ship PlayerShip { get; set; }

    private void Start ()
    {
        PlayerShip = Instantiate(shipPrefab);
        for(int i = 0; i < 5; i++)
        {
            Instantiate(meteorPrefab);
        }
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
        if (Input.GetButton("Left") || Input.GetAxisRaw("Horizontal") < 0)
        {
            PlayerShip.TurnLeft();
        }
        if (Input.GetButton("Right") || Input.GetAxisRaw("Horizontal") > 0)
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
