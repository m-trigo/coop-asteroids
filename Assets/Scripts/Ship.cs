using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject firingPoint;
    public Bullet bulletPrefab;

    private const float ACCELERATION_RATIO = 10f;
    private const float TURN_SPEED = 5f;
    private const float BULLET_SPEED = 20F;

    public void ThurstForward()
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

    public void Fire()
    {
        Bullet shot = Instantiate(bulletPrefab);
        shot.transform.position = firingPoint.transform.position;
        shot.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up) * BULLET_SPEED;
    }
}
