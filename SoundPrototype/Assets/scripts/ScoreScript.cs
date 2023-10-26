using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreCountP1, ScoreCountP2;
    private int playerOneScore, playerTwoScore;

    private void Start()
    {
        ScoreCountP1.SetText("P1 Score " + playerOneScore);
        ScoreCountP2.SetText("P2 Score " + playerTwoScore);

        DeeathScript.PlayerKilled += UpdateScore;
    }

    private void UpdateScore(int playerIndex)
    {
        if (playerIndex == 0)
        {
            playerOneScore += 1;
            ScoreCountP1.SetText("P1 Score " + playerOneScore);
        }
        else if (playerIndex == 1)
        {
            playerTwoScore += 1;
            ScoreCountP2.SetText("P2 Score " + playerTwoScore);
        }
    }
}
