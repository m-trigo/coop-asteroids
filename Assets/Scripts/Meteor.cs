using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{ 
    private const float MAX_SPEED = 4f;
    private const float MIN_SPEED = 1f;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
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
