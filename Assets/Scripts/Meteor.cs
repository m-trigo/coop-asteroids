using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Meteor[] childMeteors;

    private const float MAX_SPEED = 4f;
    private const float MIN_SPEED = 1f;

    private float QUARTER_CIRCLE_DEGREES = 90;
    private float HALF_CIRCLE_DEGREES = 180;

    private float Speed { get; set; }

    public void Initialize(float inheritedSpeed = 0)
    {
        int xMirroring = Random.Range(0, 2);
        int yMirroring = Random.Range(0, 2);
        int zMirroring = Random.Range(0, 5);

        // TODO: Find reference to angle constantss
        transform.Rotate(Vector3.right, xMirroring * HALF_CIRCLE_DEGREES);
        transform.Rotate(Vector3.up, yMirroring * HALF_CIRCLE_DEGREES);
        transform.Rotate(Vector3.forward, zMirroring * QUARTER_CIRCLE_DEGREES);

        Speed = inheritedSpeed != 0 ? inheritedSpeed : Random.Range(MIN_SPEED, MAX_SPEED);

        float velocityAngle = Random.Range(0, Mathf.PI * 2);
        float vx = Mathf.Cos(velocityAngle) * Speed;
        float vy = Mathf.Sin(velocityAngle) * Speed;
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

    private void SpawnChildMeteor()
    {
        if (childMeteors.Length > 0)
        {
            int whichMeteor = Random.Range(0, childMeteors.Length);
            Meteor child = Instantiate(childMeteors[whichMeteor]);
            child.Initialize(Speed + 1);
            child.transform.position = transform.position;
        }
    }

    private void BreakApart()
    {
        SpawnChildMeteor();
        SpawnChildMeteor();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship") || collision.CompareTag("Bullet"))
        {
            BreakApart();
        }
    }

}
