using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour
{
    public Text pointsText;
    public Text healthText;

    public Player player;
    void Start()
    {
        
    }

    void Update()
    {
        pointsText.text = "Points: " + GameManager.instanceGameManager.Score;
        healthText.text = "Health: " + player.Life;
    }
}
