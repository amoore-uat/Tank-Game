using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState
    {
        MainMenu,
        OptionsMenu,
        StartMenu,
        Gameplay,
        GameOver,
        Paused
    }

    public GameState currentGameState = GameState.MainMenu;
    public GameState previousGameState;
    public GameObject levelGameObject;
    public GameObject instantiatedPlayerTank;
    public GameObject playerTankPrefab;
    public List<GameObject> instantiatedEnemyTanks;
    public GameObject[] enemyTankPrefabs;
    public List<GameObject> playerSpawnPoints;
    public List<GameObject> enemySpawnPoints;

    // Runs before any Start() functions run
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("ERROR: There can only be one GameManager.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        instantiatedEnemyTanks = new List<GameObject>();
        playerSpawnPoints = new List<GameObject>();
        enemySpawnPoints = new List<GameObject>();
    }

    void Update()
    {
        if (instantiatedPlayerTank == null)
        {
            SpawnPlayer(RandomSpawnPoint(playerSpawnPoints));
        }
    }

    public void ChangeState(GameState newState)
    {
        switch (currentGameState)
        {
            case GameState.MainMenu:
                if (newState == GameState.OptionsMenu)
                {
                    // Disable input from main menu.
                    // Activate options menu
                }
                if (newState == GameState.StartMenu)
                {
                    // Disable input from mainmenu.
                    // Activate game start menu
                }
                break;
            case GameState.OptionsMenu:
                if (newState == GameState.MainMenu)
                {
                    // Save changes to options
                    // Deactivate options menu.
                    // Reactivate Main Menu
                }
                if (newState == GameState.Paused)
                {
                    // Save changes to options
                    // Deactivate options menu
                    // Reactivate paused menu
                }
                break;
            case GameState.StartMenu:
                if (newState == GameState.MainMenu)
                {
                    // Deactivate Start Menu
                    // Reactivate Main Menu
                }
                if (newState == GameState.Gameplay)
                {
                    // Deactivate our start menu
                    // Load our level / spawn players / spawn enemies
                    MapGenerator mapGenerator = levelGameObject.GetComponent<MapGenerator>();
                    mapGenerator.StartGame();
                }
                break;
            case GameState.Gameplay:
                if (newState == GameState.Paused)
                {
                    // Pause the simulation.
                    // Pull up pause menu.
                }
                if (newState == GameState.GameOver)
                {
                    // Handle game over behaviors
                    // Saving new high scores
                }
                break;
            case GameState.Paused:
                if (newState == GameState.Gameplay)
                {
                    // Restart the simulation
                    // Remove the pause menu
                }
                if (newState == GameState.MainMenu)
                {
                    // Switch to main menu scene/end the simulation
                    // Activate main menu
                }
                if (newState == GameState.OptionsMenu)
                {
                    // Deactivate pause menu ui
                    // Activate options menu ui
                }
                break;
            case GameState.GameOver:
                if (newState == GameState.Gameplay)
                {
                    // Reload the gameplay scene/end the simulation/restart the simulation
                }
                if (newState == GameState.MainMenu)
                {
                    // Switch to main menu scene/end the sim
                    // Activate main menu
                }
                break;
            default:
                break;
        }
        previousGameState = currentGameState;
        currentGameState = newState;
    }

    public GameObject RandomSpawnPoint(List<GameObject> spawnPoints)
    {
        // Get a random spawn point from inside our list of spawn points.
        int spawnToGet = UnityEngine.Random.Range(0, spawnPoints.Count - 1);
        return spawnPoints[spawnToGet];
    }

    public void SpawnPlayer(GameObject spawnPoint)
    {
        instantiatedPlayerTank = Instantiate(playerTankPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    public void SpawnEnemies()
    {
        // Write code for spawning enemies.
        if (enemyTankPrefabs.Length == 0)
        { Debug.LogWarning("Enemy tank prefabs is empty"); }
        for (int i = 0; i < enemyTankPrefabs.Length; ++i)
        {
            if (enemySpawnPoints.Count == 0)
            { Debug.LogWarning("Enemy spawn points list is empty."); }
            GameObject instantiatedEnemyTank =
                Instantiate(enemyTankPrefabs[i], RandomSpawnPoint(enemySpawnPoints).transform.position, Quaternion.identity);
            instantiatedEnemyTanks.Add(instantiatedEnemyTank);
        }
    }
}
