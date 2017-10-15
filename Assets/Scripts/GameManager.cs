using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Editor Side References
    public Ship shipPrefab;
    public Meteor[] meteorPrefabs;

    private Ship Player1Ship { get; set; }
    private Ship Player2Ship { get; set; }

    public static Vector2 ViewPortOrigin { get; private set; }
    public static float ScreenWidth { get; private set; }
    public static float ScreenHeight { get; private set; }

    private const int INITIAL_SPAWN_AMOUNT = 5;
    private const int SPAWN_PERIOD_IN_SECONDS = 3;

    private float timeSinceLastSpawn = 0;

    private bool CanP1Shoot { get; set; }
    private bool CanP2Shoot { get; set; }

    private void Start ()
    {
        Cursor.visible = false;
        ViewPortOrigin = Camera.main.ViewportToWorldPoint(Vector2.zero);
        ScreenWidth = Camera.main.ViewportToWorldPoint(Vector2.right).x - ViewPortOrigin.x;
        ScreenHeight = Camera.main.ViewportToWorldPoint(Vector2.up).y - ViewPortOrigin.y;

        Player1Ship = Instantiate(shipPrefab);
        Player1Ship.transform.Translate(Vector2.left * 2);
        Player2Ship = Instantiate(shipPrefab);
        Player2Ship.transform.Translate(Vector2.right * 2);
        for (int i = 0; i < INITIAL_SPAWN_AMOUNT; i++)
        {
            //SpawnMeteor();
        }

        CanP1Shoot = true;
        CanP2Shoot = true;
    }

    private void SpawnMeteor()
    {
        int whichMeteor = Random.Range(0, meteorPrefabs.Length);
        Instantiate(meteorPrefabs[whichMeteor]).Initialize();
    }

    private void ReadKeyboardInput(Ship playerShip)
    {
        if (playerShip == null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerShip.ThurstForward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerShip.TurnLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerShip.TurnRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerShip.Fire();
        }

    }

    private void ReadControllerInput(Ship playerShip, int joystickNumber)
    {
        if (playerShip == null)
        {
            return;
        }

        string radical = "P" + joystickNumber + (joystickNumber == 1 ? "PS4" : "360");

        if (Input.GetAxis(radical + "VerticalDpad") > 0 || Input.GetButton(radical + "Thrust"))
        {
            playerShip.ThurstForward();
        }
        if (Input.GetAxis(radical + "HorizontalDpad") < 0)
        {
            playerShip.TurnLeft();
        }
        if (Input.GetAxis(radical + "HorizontalDpad") > 0)
        {
            playerShip.TurnRight();
        }
        if (Input.GetButton(radical + "Fire"))
        {
            if (joystickNumber == 1)
            {
                if (CanP1Shoot)
                {
                    playerShip.Fire();
                    CanP1Shoot = false;
                }
            }
            else
            {
                if (CanP2Shoot)
                {
                    playerShip.Fire();
                    CanP2Shoot = false;
                }
            }
        }
        if (!Input.GetButton(radical + "Fire"))
        {
            if (joystickNumber == 1)
            {
                CanP1Shoot = true;
            }
            else
            {
                CanP2Shoot = true;
            }
        }

    }

    private void Update ()
    {
        ReadControllerInput(Player1Ship, 1);
        ReadControllerInput(Player2Ship, 2);

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > SPAWN_PERIOD_IN_SECONDS)
        {
            //SpawnMeteor();
            timeSinceLastSpawn = 0;
        }
    }
}
