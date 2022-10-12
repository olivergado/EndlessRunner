using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreBoard;
    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text = score.ToString();
    }
}
