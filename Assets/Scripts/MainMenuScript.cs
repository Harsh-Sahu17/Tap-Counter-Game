using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HowToPlay;
    public GameObject Settings;
    public GameObject Credits;



    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        HowToPlay.SetActive(false);
        Settings.SetActive(false);
        Credits.SetActive(false);
        Debug.Log("Start() Called");
    }

    public void SettingsBtnClicked(){
        MainMenu.SetActive(false);
        Settings.SetActive(true);
        Debug.Log("SettingsBtnClicked() Called");
    }
    public void HowToPlayBtnClicked(){
        MainMenu.SetActive(false);
        HowToPlay.SetActive(true);
        Debug.Log("HowToPlayBtnClicked() Called");
    }
    public void CreditsBtnClicked(){
        MainMenu.SetActive(false);
        Credits.SetActive(true);
        Debug.Log("CreditsBtnClicked() Called");
    }

    public void BackBtnClicked(){
        MainMenu.SetActive(true);
        HowToPlay.SetActive(false);
        Settings.SetActive(false);
        Credits.SetActive(false);
        Debug.Log("BackBtnClicked() Called");
    }

    public void PlayBtnClicked(){
        SceneManager.LoadScene("GamePlayScene");
    }

}
