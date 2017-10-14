using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Editor Side References
    public Ship shipPrefab;
    public Meteor[] meteorPrefabs;

    private Ship PlayerShip { get; set; }

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

        PlayerShip = Instantiate(shipPrefab);
        for(int i = 0; i < INITIAL_SPAWN_AMOUNT; i++)
        {
            SpawnMeteor();
        }
    }

    private void SpawnMeteor()
    {
        int whichMeteor = Random.Range(0, meteorPrefabs.Length);
        Instantiate(meteorPrefabs[whichMeteor]);
    }

    private void ReadKeyboardInput()
    {
        if (PlayerShip == null)
        {
            return;
        }

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

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > SPAWN_PERIOD_IN_SECONDS)
        {
            SpawnMeteor();
            timeSinceLastSpawn = 0;
        }
    }
}
