using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private float Size { get; set; }
    private const float MAX_SPEED = 4f;
    private const float MIN_SPEED = 1f;
    
    private void Initialize()
    {
        Size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(Size, Size, 1);
        
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
            yOfSpawn = (PlayArea.SIZE/2 + Size) * (isGoingUp ? -1 : 1);
            xOfSpawn = Random.Range(-0.5f, 0.5f) * PlayArea.SIZE;
        }
        else
        {
            bool isGoingRight = vx > 0;
            xOfSpawn = (PlayArea.SIZE/2 + Size) * (isGoingRight ? -1 : 1);
            yOfSpawn = Random.Range(-0.5f, 0.5f) * PlayArea.SIZE;
        } 

        transform.position = new Vector2(xOfSpawn, yOfSpawn);
    }

    private void Start ()
    {
        Initialize();
    }

    private void Update()
    {
        float distance = PlayArea.SIZE/2 + Size;
        if (transform.position.x > distance || transform.position.y > distance
            || transform.position.x < -distance || transform.position.y < -distance)
        {
            Initialize();
        }
    }
}
