using System.Collections;
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
        CheckGameOver();
        bomb.SpawnBombs();
        bomb.DeleteBombs();
    }

    private void CheckGameOver()
    {
        if (player.IsAlive())
        {
            //ScenesManager.instanceScenesManager.ChangeScene("GamveOver");
        }
    }
}
