using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerlife;
    public int playermana;
    public int playerlevel;
    public int playerskillpoints;
    public GameObject player;
    public TextMeshProUGUI life;
    public TextMeshProUGUI level;
    public TextMeshProUGUI skillpoints;
    public float[] position;
    public int playerClass;
    public int[] skills;
    void Start()
    {
        skills = new int[2];
        Playerstatus();
    }

   

    // Update is called once per frame
    void Update()
    {
        life.text = playerlife.ToString();
        level.text = playerlevel.ToString();
        skillpoints.text = "Pontos disponiveis: " + playerskillpoints;
        
    }
    public void Playerstatus()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void GetPosition()
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

    public void Getback()
    {
        SceneManager.LoadScene("TitleScreen");
        PlayerPrefs.DeleteAll();
    }
}
