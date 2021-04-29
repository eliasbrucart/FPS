using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    public Text pointsEarned;

    void Update()
    {
        pointsEarned.text = "Points Earned: " + GameManager.instanceGameManager.Score;
    }
}
