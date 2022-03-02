using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace elikrisel
{
    public class ScoreHandler : MonoBehaviour
    {
        //Instance of score handler
        public static ScoreHandler instance;

        
        
        [SerializeField] private Text scoreText;
        [SerializeField] private Text highscoreText;

        private int score = 0;
        private int highScore = 0;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            highScore = PlayerPrefs.GetInt("highscore", 0);
            scoreText.text = score.ToString() + "";
            highscoreText.text = "HIGHSCORE: " + highScore.ToString();

        }

        
        public void AddScore()
        {
            score += 1;
            scoreText.text = "" + score.ToString();
            if(highScore < score)
            {   
                PlayerPrefs.SetInt("highscore", score);
            }

        }


    }

}

