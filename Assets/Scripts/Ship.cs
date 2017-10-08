using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private static float ACCELERATION_RATIO = 4f;
    private static float TURN_SPEED = 2f;

    public void Accelerate()
    {
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * ACCELERATION_RATIO);
    }

    public void TurnLeft()
    {
        GetComponent<Rigidbody2D>().rotation += TURN_SPEED;
    }

    public void TurnRight()
    {
        GetComponent<Rigidbody2D>().rotation -= TURN_SPEED;
    }
}
