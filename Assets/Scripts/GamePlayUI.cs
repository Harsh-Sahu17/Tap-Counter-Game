using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{

    public GameObject TapCountText;
    public GameManager gameManager;
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public Text TimerText;
    public Text HighScoreText;
    public GameObject ResumePanel;
    public bool isPause;
    public Text CountDownTimerText;

    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "";
        
    }

    public void BackBtnClicked(){
        SceneManager.LoadScene(0);
    }

    private void Update(){
        TimerText.text = "Timer: " + gameManager.Timer.ToString();
        if(!gameManager.CountDownTimerHasEnded)
            CountDownTimerText.text = gameManager.CountDownTimer.ToString();
    }

    public void DisableCountDownTimer(){
        CountDownTimerText.gameObject.SetActive(false);
    }

   
    public void UpdateTapCountText(){
        TapCountText.GetComponent<Text>().text = "Tap Count : " + gameManager.tapCount.ToString();
        Debug.Log("Updating UI");
    }

    public void EndGame(){
        if(gameManager.HasWon == true){
            WinPanel.SetActive(true);
        } // we have won
        else {
            GameOverPanel.SetActive(true);
        }

    }

    public void ShowHighScore(){
        HighScoreText.text = "HighScore : " + GameManager.HighScore.ToString();
    }

    public void RestartGame(){
        SceneManager.LoadScene(1);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void Pause(){
        ResumePanel.SetActive(true);
        isPause = true;
        Time.timeScale = 0;
    }

    public void Resume(){
        ResumePanel.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
    }

    public void NextLevel(){
        gameManager.IncreaseLevel();
        Debug.Log("going to next level" + gameManager.GetLevelNum());

    }


}
