//Handles save

using Character;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI.Menus;
using UnityEngine;
using static ZombieSpawner;


//Has all data that has to be saved
[System.Serializable]
public class GameSaveData
{
    public PlayerSaveData PlayerSaveData;
    public SpawnerSaveDataList SpawnerSaveDataList;

    public GameSaveData()
    {
        PlayerSaveData = new PlayerSaveData();
    }
}

[System.Serializable]
public class SpawnerSaveDataList
{
    public List<SpawnerSaveData> SpawnerData = new List<SpawnerSaveData>();
}

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    private GameSaveData GameSave;

    private const string SaveFileKey = "FileSaveData";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //If we don't have selected save name
        if(string.IsNullOrEmpty(GameManager.Instance.SelectedSaveName))
        {
            return;
        }

        //If we don't have save data in PlayerPrefs
        if(PlayerPrefs.HasKey(GameManager.Instance.SelectedSaveName) == false)
        {
            return;
        }

        //Load SelectedSaveName to json string
        string jsonString = PlayerPrefs.GetString(GameManager.Instance.SelectedSaveName);
        GameSave = JsonUtility.FromJson<GameSaveData>(jsonString);
        LoadGame();
    }

    public void SaveGame()
    {
        //Check if GameSave is null, if null make new GameSaveData, if not null, ignore
        GameSave ??= new GameSaveData();

        //Find all MonoBehaviour and check if that's ISavable
        var savableObjects = FindObjectsOfType<MonoBehaviour>().Where(monoObject => monoObject is ISavable).ToList();

        //Find PlayerController in all savableObjects
        ISavable playerSaveObject = savableObjects.First(monoObject => monoObject is PlayerController) as ISavable;
        GameSave.PlayerSaveData = (PlayerSaveData)playerSaveObject?.SaveData();

        //Find zombieSpawner
        SpawnerSaveDataList spawnerList = new SpawnerSaveDataList();
        var spawnerDataList = savableObjects.OfType<ZombieSpawner>();
        foreach(ZombieSpawner spawner in spawnerDataList)
        {
            ISavable saveObject = spawner.GetComponent<ISavable>();
            spawnerList.SpawnerData.Add(saveObject?.SaveData() as SpawnerSaveData);
        }

        GameSave.SpawnerSaveDataList = spawnerList;

        //convert GameSaveData to json and save it to PlayerPrefs
        string jsonString = JsonUtility.ToJson(GameSave);
        //Overwrite SelectedSaveName data
        PlayerPrefs.SetString(GameManager.Instance.SelectedSaveName, jsonString);

        SaveToGameSaveList();
    }

    private void SaveToGameSaveList()
    {
        //If we have SaveFileKey(list of save file name)
        if(PlayerPrefs.HasKey(SaveFileKey))
        {
            //Get list of save file name
            GameDataList saveList = JsonUtility.FromJson<GameDataList>(PlayerPrefs.GetString(SaveFileKey));
            
            //Check if SelectedSaveName is in list of save file name, if it's in, don't do anything, we already overwirted the data
            if(saveList.SaveFileNames.Contains(GameManager.Instance.SelectedSaveName))
            {
                return;
            }

            //If we don't have SelectedSaveName inside list of save file names, we need to make new save file name
            saveList.SaveFileNames.Add(GameManager.Instance.SelectedSaveName);
            //And then save list of save file name.
            PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(saveList));
        }
        //If we don't have SaveFileKey(list of save file names)
        else
        {
            //Make new list of save file names and add SelectedSaveName
            GameDataList saveList = new GameDataList();
            saveList.SaveFileNames.Add(GameManager.Instance.SelectedSaveName);

            //and save it to PlayerPRefs
            PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(saveList));
        }
    }


    public void LoadGame()
    {
        //Find all MonoBehaviour and check if that's ISavable
        var savableObjects = FindObjectsOfType<MonoBehaviour>().Where(monoObject => monoObject is ISavable).ToList();

        //Find player controller in savableObjects and load data
        ISavable playerObject = savableObjects.First(monoObject => monoObject is PlayerController) as ISavable;
        playerObject?.LoadData(GameSave.PlayerSaveData);

        foreach(SpawnerSaveData spawnerData in GameSave.SpawnerSaveDataList.SpawnerData)
        {
            ISavable saveObject = savableObjects.Find(savableObject => spawnerData.Name == savableObject.name) as ISavable;
            saveObject?.LoadData(spawnerData);
        }
    }
}
