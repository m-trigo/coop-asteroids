using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Editor Side Dependency Injection
    public Ship shipPrefab;
    public Meteor meteorPrefab;

    private Ship PlayerShip { get; set; }

    public Vector2 ViewPortOrigin { get; private set; }
    public static float ScreenWidth { get; private set; }
    public static float ScreenHeight { get; private set; }
   
    private void Start ()
    {
        ViewPortOrigin = Camera.main.ViewportToWorldPoint(Vector2.zero);
        ScreenWidth = Camera.main.ViewportToWorldPoint(Vector2.right).x - ViewPortOrigin.x;
        ScreenHeight = Camera.main.ViewportToWorldPoint(Vector2.up).y - ViewPortOrigin.y;

        PlayerShip = Instantiate(shipPrefab);
        Instantiate(meteorPrefab);
    }

    private void ReadKeyboardInput()
    {
        if (!PlayerShip.enabled)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            PlayerShip.ThurstForward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerShip.TurnLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerShip.TurnRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {        
            PlayerShip.Fire();
        }

    }

    private void Update ()
    {
        ReadKeyboardInput();
    }
}
