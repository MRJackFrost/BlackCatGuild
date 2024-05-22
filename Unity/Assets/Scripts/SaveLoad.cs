using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager manager;
    public ClassChoice classChoice;
    
    void Start()
    {
        
       
    }

    public void SaveButton()
    {
        manager.GetPosition();
        PlayerData data = new PlayerData
        {
            playerLife = manager.playerlife,
            playerLevel = manager.playerlevel,
            playerClass = manager.playerClass,
            playerMana = 0,
            skillpoints = manager.playerskillpoints
        };
        data.position = new float[3];
        data.position[0] = manager.position[0];
        data.position[1] = manager.position[1];
        data.position[2] = manager.position[2];
        data.skills = new int[2];
        data.skills[0] = manager.skills[0];
        data.skills[1] = manager.skills[1];
        SaveGame(data);
    }

    public void LoadButton()
    {
        PlayerData load = LoadGame();
        manager.playerlife = load.playerLife;
        manager.playerlevel = load.playerLevel;
        Vector3 position;
        position.x = load.position[0];
        position.y = load.position[1];
        position.z = load.position[2];
        manager.player.transform.position = position;
    }

    public void SaveGame(PlayerData data)
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath;
        FileStream file = File.Create(path + "/BlackCat.save");
        
        binary.Serialize(file, data);
        file.Close();
        
        Debug.Log("Game Saved");
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
