using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour
{
    public Text pointsText;
    public Text highScoreText;
    public Text healthText;

    public Player player;
    void Start()
    {
        
    }

    void Update()
    {
        pointsText.text = "Points: " + GameManager.instanceGameManager.Score;
        highScoreText.text = "High Score: " + GameManager.instanceGameManager.HighScore;
        healthText.text = "Health: " + player.Life;
    }
}
