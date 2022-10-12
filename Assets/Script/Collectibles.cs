using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            scoreManager = GameObject.Find("Scoreboard").GetComponent<ScoreManager>();
            scoreManager.score = scoreManager.score + 1;

            Destroy(gameObject);
            

        }
    }
}
