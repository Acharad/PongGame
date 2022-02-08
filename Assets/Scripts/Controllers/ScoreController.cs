using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] int scorePlayer1 = 0;
    [SerializeField] int scorePlayer2 = 0;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    public int goalToWin;

    private void Update()
    {
        if(this.scorePlayer1 >= this.goalToWin || this.scorePlayer2 >= this.goalToWin)
        {
            SceneManager.LoadScene("GameOver");
        }   
    } 

    private void FixedUpdate()
    {
        Text uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<Text>();
        uiScorePlayer1.text = this.scorePlayer1.ToString();

        Text uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<Text>();
        uiScorePlayer2.text = this.scorePlayer2.ToString();
    }

    public void GoalPlayer(bool isPlayer1)
    {
        if(isPlayer1)
        {
            this.scorePlayer1++;
        }
        else
        {
            this.scorePlayer2++;
        }
    }
}
