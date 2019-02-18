﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    // configuration parameters
    [SerializeField] int startingHealth = 10;

    // cached parameters
    LevelController levelController;

    // state parameters
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleHit(collision);
    }

    private void HandleHit(Collider2D collision)
    {
        currentHealth--;
        levelController.DecrementAliveAttackers();
        Destroy(collision.gameObject);

        if (currentHealth <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadLossScene();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
