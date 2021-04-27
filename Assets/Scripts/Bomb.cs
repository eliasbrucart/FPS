﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bombPrefab;
    public List<GameObject> bombsRandom = new List<GameObject>();

    [SerializeField] private int amountOfBombs;

    private float timeToSpawn;
    private float timeToDelete;
    void Start()
    {
        
    }

    void Update()
    {
             
    }

    public void SpawnBombs()
    {
        timeToSpawn += Time.deltaTime;
        if (timeToSpawn >= 10.0f)
        {
            for (int i = 0; i < amountOfBombs; i++)
            {
                float randomX = Random.Range(40.0f, 130.0f);
                float randomZ = Random.Range(40.0f, 210.0f);
                GameObject go = Instantiate(bombPrefab, new Vector3(randomX, 0.0f, randomZ), Quaternion.identity);
                bombsRandom.Add(go);
            }
            timeToSpawn = 0.0f;
        }
    }

    public void DeleteBombs()
    {
        timeToDelete += Time.deltaTime;
        if(timeToDelete >= 15.0f)
        {
            for(int i = 0; i < bombsRandom.Count; i++)
            {
                Destroy(bombsRandom[i].gameObject);
            }
            timeToDelete = 0.0f;
        }
    }
}
