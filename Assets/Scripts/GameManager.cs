using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Editor Side Dependency Injection
    public Ship shipPrefab;

    private Ship PlayerShip { get; set; }

	void Start ()
    {
        PlayerShip = Instantiate(shipPrefab);
	}

	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerShip.Accelerate();
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
}
