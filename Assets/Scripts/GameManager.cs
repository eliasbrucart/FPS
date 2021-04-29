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
    public Box box;
    public Gun gun;

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
        bomb.SpawnBomb();
        bomb.DeleteBomb();
        box.SpawnBox();
        box.DeleteBox();
        KillEnemy();
        CheckGameOver();
    }

    private void KillEnemy()
    {
        if (gun.Shoot())
            score += 100;
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
}
