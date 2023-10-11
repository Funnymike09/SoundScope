using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeeathScript : MonoBehaviour
{
    public static event Action<DeeathScript> Killed;
    [SerializeField] float health, maxHealth = 1f;

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
}
