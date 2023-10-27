using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using OpenCover.Framework.Model;

public class DeeathScript : MonoBehaviour
{
    public static event Action<DeeathScript> Killed;
   // public static Action<int> PlayerKilled = delegate { };
    public static Action Score = delegate { };
    [SerializeField] float health, maxHealth = 1f;

    public int PlayerIndex { get; private set; }

    void Start()
    {
        health = maxHealth;
         
    }

    public void TakeDamage(float damageAmaunt)
    {
        health -= damageAmaunt;
        
        if (health <= 0f)
        {
           // PlayerKilled(PlayerIndex);
            Score();
             Killed?.Invoke(this);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            
            
        }
    }
}
