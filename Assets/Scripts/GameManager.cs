using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SpawnMeteor();
        }
    }

    private void SpawnMeteor()
    {
        int whichMeteor = Random.Range(0, meteorPrefabs.Length);
        Instantiate(meteorPrefabs[whichMeteor]).Initialize();
    }


    private void ReadP1KeyboardInput()
    {
        if (Player1Ship == null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Player1Ship.ThurstForward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            Player1Ship.TurnLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player1Ship.TurnRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player1Ship.Fire();
        }
    }

    private void ReadP2KeyboardInput()
    {
        if (Player2Ship == null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Player2Ship.ThurstForward();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player2Ship.TurnLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Player2Ship.TurnRight();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Player2Ship.Fire();
        }
    }


    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Main");
        }

        ReadP1KeyboardInput();
        ReadP2KeyboardInput();

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > SPAWN_PERIOD_IN_SECONDS)
        {
            SpawnMeteor();
            timeSinceLastSpawn = 0;
        }
    }
}
