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

    private void FixedUpdate ()
    {
        ReadKeyboardInput();
    }
}
