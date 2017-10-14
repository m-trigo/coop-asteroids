using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    public string Direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            return;
        }

        if (Direction.Equals("Horizontal"))
        {
            float y = collision.transform.position.y;
            y = -y + (y > 0 ? 1 : -1);
            collision.transform.position = new Vector2(collision.transform.position.x, y);
        }
        else
        {
            float x = collision.transform.position.x;
            x = -x + (x > 0 ? 1 : -1);
            collision.transform.position = new Vector2(x, collision.transform.position.y);
        }
    }
}
