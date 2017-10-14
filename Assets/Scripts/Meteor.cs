using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Sprite[] Sprites;

    private const float MAX_SPEED = 4f;
    private const float MIN_SPEED = 1f;

    private int Size { get; set; }

    private void Initialize()
    {
        Size = Random.Range(0, Sprites.Length);

        GetComponent<SpriteRenderer>().sprite = Sprites[Size];
        PolygonCollider2D collider = gameObject.AddComponent<PolygonCollider2D>();
        collider.isTrigger = true;

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
            yOfSpawn = 11 * (isGoingUp ? -1 : 1);
            xOfSpawn = Random.Range(-0.5f, 0.5f) * 11;
        }
        else
        {
            bool isGoingRight = vx > 0;
            xOfSpawn = 11 * (isGoingRight ? -1 : 1);
            yOfSpawn = Random.Range(-0.5f, 0.5f) * 11;
        }

        transform.position = new Vector2(xOfSpawn, yOfSpawn);
    }
}
