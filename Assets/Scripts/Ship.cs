using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject firingPoint;
    public Bullet bulletPrefab;

    private static float ACCELERATION_RATIO = 4f;
    private static float TURN_SPEED = 2f;
    private static float BULLET_SPEED = 20F;

    public Bullet CurrentBullet { get; set; }

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
        if (CurrentBullet == null)
        {
            CurrentBullet = Instantiate(bulletPrefab);
            CurrentBullet.Source = this;
            CurrentBullet.transform.position = firingPoint.transform.position;
            CurrentBullet.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up) * BULLET_SPEED;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        gameObject.SetActive(false);
    }
}
