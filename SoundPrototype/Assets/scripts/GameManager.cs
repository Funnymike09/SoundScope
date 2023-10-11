using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    //bruh
    public static GameManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

    }

    private void Start()
    {
        PlayerInputManager.instance.JoinPlayer(0, -1, null);
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("bruh");
    }

    private void OnPlayerLeft(PlayerInput playerInput)
    {

    }
}
