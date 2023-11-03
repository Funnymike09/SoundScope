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
    [SerializeField] private TMP_Text Player1Win, Player2Win;
    private static int playerOneScore, playerTwoScore;
    public static ScoreScript instance;
    private PlayerConfiguration playerConfig;


    private void Start()
    {
        ScoreCountP1.SetText("P1 Score " + playerOneScore);
        ScoreCountP2.SetText("P2 Score " + playerTwoScore);
        

        DeeathScript.Score += UpdateScore;
    }

    public void textColor(PlayerConfiguration pc)
    {
        playerConfig = pc;
        ScoreCountP1.material = pc.TextMaterial;
        ScoreCountP2.material = pc.TextMaterial;
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

    private void Update()
    {
        if (playerOneScore >= 3f)
        {
            Player1Win.enabled = true;
        }

        if (playerTwoScore >= 3) 
        {
            Player2Win.enabled = true;
        }
    }

    private void OnDestroy()
    {
        DeeathScript.Score -= UpdateScore;
    }
   
}
