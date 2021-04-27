using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instanceGameManager;

    static public GameManager Instance { get { return instanceGameManager; } }

    [SerializeField] private int score;

    public Player player;

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
    }

    private void CheckGameOver()
    {
        if (player.IsAlive())
        {
            ScenesManager.instanceScenesManager.ChangeScene("GamveOver");
        }
    }
}
