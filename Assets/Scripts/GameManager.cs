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
        for(int i = 0; i < 5; i++)
        {
            Instantiate(meteorPrefab);
        }

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
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerShip.Fire();
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
        if (Input.GetButton("Fire1"))
        {
            PlayerShip.Fire();
        }
    }

    private void FixedUpdate ()
    {
        ReadKeyboardInput();
        ReadControllerInput();
    }
}
