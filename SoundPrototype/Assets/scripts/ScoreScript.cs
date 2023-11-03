using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EasyPhysicsSurfaces;
using UnityEngine.InputSystem;

public class ScoreScript : MonoBehaviour
{
    
    [SerializeField] private TMP_Text ScoreCountP1, ScoreCountP2;
    private static int playerOneScore, playerTwoScore;
    public static ScoreScript instance;
    
    private void Start()
    {
        ScoreCountP1.SetText("P1 Score " + playerOneScore);
        ScoreCountP2.SetText("P2 Score " + playerTwoScore);

        DeeathScript.Score += UpdateScore;
    }
    

    private void UpdateScore(int pi)
    {
        if (pi == 0)
        {
            playerTwoScore ++;
            ScoreCountP1.SetText("P1 Score " + playerOneScore);
        }
        else if (pi == 1)
        {
            playerOneScore ++;
            ScoreCountP2.SetText("P2 Score " + playerTwoScore);
        }
    }
  
    private void OnDestroy()
    {
        DeeathScript.Score -= UpdateScore;
    }
   
}
