﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instanceGameManager;

    static public GameManager Instance { get { return instanceGameManager; } }

    [SerializeField] private int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public Player player;
    public Bomb bomb;
    public Box box;

    private void Awake()
    {
        if(instanceGameManager != null && instanceGameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanceGameManager = this;
        }
    }
    void Start()
    {
    }

    void Update()
    {
        bomb.SpawnBombs();
        bomb.DeleteBombs();
        box.SpawnBox();
        box.DeleteBox();
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (!player.IsAlive())
        {
            ScenesManager.instanceScenesManager.ChangeScene("GameOver");
        }
    }
}
