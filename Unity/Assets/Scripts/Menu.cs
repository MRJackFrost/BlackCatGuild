using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Classchoicepanel;
    public GameObject Menupanel;
    public string scenenam;
    public int gameType; //1 - NewGame // 2 - LoadGame
    public void ClassChoise()
    {
        Classchoicepanel.SetActive(true);
        Menupanel.SetActive(false);
    }
    public void Backtomenu()
    {
        Classchoicepanel.SetActive(false);
        Menupanel.SetActive(true);
    }

    public void Startlevel(int classchoice)
    {
        PlayerPrefs.SetInt("classe", classchoice);
        gameType = 1;
        PlayerPrefs.SetInt("gametype", gameType);
        SceneManager.LoadScene(scenenam);
    }

    public void LoadLevel()
    {
        gameType = 2;
        PlayerPrefs.SetInt("gametype", gameType);
        SceneManager.LoadScene(scenenam);
    }
}
