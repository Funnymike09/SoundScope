using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private SceneController controller;
    private CarControlls controls;
    public int pointPlayer1;
    public int pointPlayer2;
    void Start()
    {
        pointPlayer1 = 0;
        pointPlayer2 = 0;
    }

}
