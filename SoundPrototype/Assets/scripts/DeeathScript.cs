using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DeeathScript : MonoBehaviour
{
    public static event Action<DeeathScript> Killed;
    [SerializeField] float health, maxHealth = 1f;
    private SceneController controller;
    private CarControlls controls;

    void Start()
    {
        health = maxHealth;
         
    }

    public void TakeDamage(float damageAmaunt)
    {
        health -= damageAmaunt;
        
        if (health <= 0f)
        {
            Destroy(gameObject);
            Killed?.Invoke(this);
            
        }
    }
    public void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
