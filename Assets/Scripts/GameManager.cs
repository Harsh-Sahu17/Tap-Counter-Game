using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int tapCount;
    public GamePlayUI gameplayUI;
    public float DefaultTimerValue = 30;
    public float Timer;
    public bool TimerHasEnded = false;
    int TargetCount;
    public bool HasWon;
    public static int HighScore;
    public float CountDownTimer;
    public bool CountDownTimerHasEnded;
    int LevelNum = 1;
    int baseLevelMultiplier = 10;

    

    // Start is called before the first frame update
    void Start()
    {
        CountDownTimer = 3;
        CountDownTimerHasEnded = false;
        GetHighScore();
        Timer = DefaultTimerValue;

        TargetCount = HighScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!CountDownTimerHasEnded){
            CountDownTimer -= Time.deltaTime;
        
        if(CountDownTimer <= 0){
            CountDownTimerHasEnded =  true;
            gameplayUI.DisableCountDownTimer();
        }

        }


        if(CountDownTimerHasEnded && TimerHasEnded == false){
            Timer -= Time.deltaTime;

            if(Timer <= 0){
                TimerHasEnded = true;
                Timer = 0;
                if(tapCount > TargetCount){
                    HasWon = true;
                }
                else{
                    HasWon = false;
                }
                gameplayUI.EndGame();
                // Game is over
                if(tapCount > HighScore){
                    HighScore = tapCount;
                }

                gameplayUI.ShowHighScore();

                SaveHighScore();

                //Debug.Log("Highscore is : "+HighScore);
                //Debug.Log("Timer has Ended : HasWon"+HasWon.ToString());
            }
            

        if(gameplayUI.isPause == false && Input.GetMouseButtonDown(0)){
            tapCount = tapCount + 1;
            gameplayUI.UpdateTapCountText();
            //Debug.Log("Click Dectected : "+tapCount);

        }
        }

    }
    public void SaveHighScore(){
        PlayerPrefs.SetInt("HighScore", HighScore);
        //Debug.Log("HighScore is Saved");
    }

    public void GetHighScore(){
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    int GetTapTargetCount(int _levelNum){
        int _temp = 0;
        _temp = baseLevelMultiplier + _levelNum;

        return _temp;
    }
    
    public void IncreaseLevel(){
        LevelNum++;
    }

    public int GetLevelNum(){
        return LevelNum;
    }


}
