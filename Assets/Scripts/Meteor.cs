using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{ 
    private const float MAX_SPEED = 4f;
    private const float MIN_SPEED = 1f;

    private float QUARTER_CIRCLE_DEGREES = 90;
    private float HALF_CIRCLE_DEGREES = 180;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        int xMirroring = Random.Range(0, 2);
        int yMirroring = Random.Range(0, 2);
        int zMirroring = Random.Range(0, 5);

        // TODO: Find reference to angle constantss
        transform.Rotate(Vector3.right, xMirroring * HALF_CIRCLE_DEGREES);
        transform.Rotate(Vector3.up, yMirroring * HALF_CIRCLE_DEGREES);
        transform.Rotate(Vector3.forward, zMirroring * QUARTER_CIRCLE_DEGREES);


        float speed = Random.Range(MIN_SPEED, MAX_SPEED);
        float velocityAngle = Random.Range(0, Mathf.PI * 2);
        float vx = Mathf.Cos(velocityAngle) * speed;
        float vy = Mathf.Sin(velocityAngle) * speed;
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);

        float xOfSpawn = 0;
        float yOfSpawn = 0;
        bool isVertical = Mathf.Abs(vy) > Mathf.Abs(vx);
        if (isVertical)
        {
            bool isGoingUp = vy > 0;
            yOfSpawn = GameManager.ScreenHeight * (isGoingUp ? -0.5f : 0.5f) + (isGoingUp ? -1f : 1f);
            xOfSpawn = Random.Range(-0.5f, 0.5f) * GameManager.ScreenWidth;
        }
        else
        {
            bool isGoingRight = vx > 0;
            xOfSpawn = GameManager.ScreenWidth * (isGoingRight ? -0.5f : 0.5f) + (isGoingRight ? -1 : 1);
            yOfSpawn = Random.Range(-0.5f, 0.5f) * GameManager.ScreenHeight;
        }

        transform.position = new Vector2(xOfSpawn, yOfSpawn);
    }
}
