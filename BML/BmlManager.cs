using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Android;
using System.Collections;

public class BmlManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int score;
        public float health;
    }
    public PlayerData playerData;
    private string filePath;
    //hetyknhqmaygdnudfkcar2aitdqbcfhria4brp3cyixnjsdtkaqq
    private void Awake()
    {
        // Define the file path for the .bml file
        filePath = Application.persistentDataPath + "/playerData.bml";
        Debug.Log(filePath);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveData(playerData);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
        }
    }

    public void SaveData(PlayerData data)
    {
        // Serialize the data into binary format
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public PlayerData LoadData()
    {
        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Deserialize the data from binary format
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);
            playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return playerData;
        }
        else
        {
            Debug.LogError("File not found!");
            return null;
        }
    }
}
