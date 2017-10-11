using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Ship Source { get; set; }

    private void CleanUp()
    {
        Source.CurrentBullet = null;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CleanUp();
    }

    private void Update()
    {
        float distance = PlayArea.SIZE / 2;
        if (transform.position.x > distance || transform.position.y > distance
            || transform.position.x < -distance || transform.position.y < -distance)
        {
            CleanUp();
        }
    }
}
