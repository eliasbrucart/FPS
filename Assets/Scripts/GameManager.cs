using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instanceGameManager;

    static public GameManager Instance { get { return instanceGameManager; } }

    [SerializeField] private int score;
    [SerializeField] private int highScore;

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

    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
        }
    }

    public Player player;
    public Bomb bomb;
    public Box box;
    public Gun gun;
    public Spawner spawner;

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
        Gun.AddScore += KillEnemy;
        HighScore = PlayerPrefs.GetInt("highScore");
    }

    void Update()
    {
        HighScore = PlayerPrefs.GetInt("highScore");
        //bomb.SpawnBomb();
        //bomb.DeleteBomb();
        //box.SpawnBox();
        //box.DeleteBox();
        spawner.SpawnQueue();
        //KillEnemy();
        CheckGameOver();
    }

    private void KillEnemy(Gun gun)
    {
        score += 100;
        if(score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }   
    }

    private void CheckGameOver()
    {
        if (!player.IsAlive())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ScenesManager.instanceScenesManager.ChangeScene("GameOver");
        }
    }

    private void OnDestroy()
    {
        Gun.AddScore -= KillEnemy;
    }
}
