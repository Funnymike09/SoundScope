using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class DeeathScript : MonoBehaviour
{
    public static event Action<DeeathScript> Killed;
   // public static Action<int> PlayerKilled = delegate { };
    public static Action<int> Score = delegate { };
    [SerializeField] float health, maxHealth = 1f;
    public PlayerInput input;
    public ParticleSystem bloodParticle;
    [SerializeField] 

    private int playerIndex;

    void Start()
    {
        health = maxHealth;

        getTheIndex(input.playerIndex);
         
    }

    public void TakeDamage(float damageAmaunt)
    {
        health -= damageAmaunt;
        
        if (health <= 0f)
        {
           // PlayerKilled(PlayerIndex);
            Score(playerIndex);
             Killed?.Invoke(this);
            bloodParticle.Play();
            
            StartCoroutine(roundEnd());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            
            
        }
    }
    public void getTheIndex(int pi)
    {
        playerIndex = pi;
    }

    public IEnumerator roundEnd()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
