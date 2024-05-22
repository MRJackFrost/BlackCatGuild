using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ClassChoice : MonoBehaviour
{
    public bool warrior;
    public bool mage;
    public bool thief;

    public GameObject warriorobj;
    public GameObject magebj;
    public GameObject thiefobj;
    public GameObject canvas;
    // Start is called before the first frame update
    public int gameType;
    public GameManager manager;
    
    void Start()
    {
        gameType = PlayerPrefs.GetInt("gametype");
        if (gameType == 1)
        {
            Classintante(PlayerPrefs.GetInt("classe"));
            manager.playerClass = PlayerPrefs.GetInt("classe");
        }

        else if (gameType == 2)
        {
            LoadMenu();
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu()
    {
        PlayerData load = LoadGame();
        Debug.Log(load.playerClass);
        manager.playerClass = load.playerClass;
        Classintante(load.playerClass);
        manager.Playerstatus();
        Debug.Log(load.playerLife);
        manager.playerlife = load.playerLife;
        manager.playerlevel = load.playerLevel;
        Vector3 position;
        position.x = load.position[0];
        position.y = load.position[1];
        position.z = load.position[2];
        manager.player.transform.position = position;
        manager.skills = new int[2];
        manager.skills[0] = load.skills[0];
        manager.skills[1] = load.skills[1];
        manager.playerskillpoints = load.skillpoints;
    }

    public void Classintante(int classeload)
    {
        if ( classeload == 1)
        {
            Instantiate(warriorobj);
        }else if (classeload == 2)
        {
            Instantiate(thiefobj);
        }
        else
        {
            Instantiate(magebj);
        }
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public PlayerData LoadGame()
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath;
        FileStream file;
        if (File.Exists(path + "/BlackCat.save"))
        {
            file = File.Open(path + "/BlackCat.save", FileMode.Open);
            PlayerData loadFile = (PlayerData)binary.Deserialize(file);
            file.Close();
            Debug.Log("Game Loaded");
            return loadFile;
        }

        return null;
    }
}
