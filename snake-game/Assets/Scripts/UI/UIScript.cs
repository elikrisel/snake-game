using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace elikrisel
{
    public class UIScript : MonoBehaviour
    {/// <summary>
    /// Simple as straight forward UI Script for button functionality
    /// </summary>

        [Header("UI Components")]
        [SerializeField] private GameObject resumeButton;
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject gameOverScreen;

        [SerializeField] private GameObject gameisPausedText;
        [SerializeField] private GameObject readyText;
        [SerializeField] private GameObject playButton;

     
        private void Start()
        {
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
            gameOverScreen.SetActive(false);

            playButton.SetActive(true);
            readyText.SetActive(true);
            gameisPausedText.SetActive(false);
            
            Time.timeScale = 0;
            

        }

        public void Pause()
        {
            gameisPausedText.SetActive(true);
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
            Time.timeScale = 0;
                

        }
        public void Resume()
        {
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
            Time.timeScale = 1;

        }
        

        public void Quit()
        {
            Application.Quit();

        }
        public void Restart()
        {

            SceneManager.LoadSceneAsync(0);

        }
        public void PlayGame()
        {
            playButton.SetActive(false);
            readyText.SetActive(false);
            Time.timeScale = 1;
        }
        public void GameOver()
        {

            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }


    }


}