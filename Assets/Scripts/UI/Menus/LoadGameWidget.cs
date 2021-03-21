using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

namespace UI.Menus
{
    public class LoadGameWidget : MenuWidget
    {
        private GameDataList GameData;

        [Header("Scene To Load")]
        [SerializeField] string SceneToLoad;

        [Header("Referneces")]
        [SerializeField] private RectTransform LoadItemsPanel;
        [SerializeField] private TMP_InputField NewGameInputField;

        [Header("Prefabs")]
        [SerializeField] GameObject SaveSlotPrefab;

        [SerializeField] bool Debug;
        private const string SaveFileKey = "FileSaveData";

        // Start is called before the first frame update
        void Start()
        {
            if(Debug)
            {
                SaveDebugData();
            }

            //Before loading, delete example slot from load item panel
            WipeChildren();

            //Load game data and creaet save slot
            LoadGameData();
        }

        private void WipeChildren()
        {
            foreach(RectTransform saveSlot in LoadItemsPanel)
            {
                Destroy(saveSlot.gameObject);
            }

            LoadItemsPanel.DetachChildren();
        }

        private static void SaveDebugData()
        {
            GameDataList dataList = new GameDataList();
            dataList.SaveFileNames.AddRange(new List<string> { "Save1", "Save2", "Save3" });

            PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(dataList));
        }

        private void LoadGameData()
        {
            //If we don't have save file key
            if(PlayerPrefs.HasKey(SaveFileKey) == false)
            {
                return;
            }

            //Get jason string
            string jsonString = PlayerPrefs.GetString(SaveFileKey);

            //convert jsonstring to class 
            GameData = JsonUtility.FromJson<GameDataList>(jsonString);

            if(GameData.SaveFileNames.Count <= 0)
            {
                return;
            }

            foreach(string saveName in GameData.SaveFileNames)
            {
                SaveSlotWidget widget = Instantiate(SaveSlotPrefab, LoadItemsPanel).GetComponent<SaveSlotWidget>();
                widget.Initialize(this, saveName);
                //widget.SetParent(LoadItemsPanel);
            }

            //UnityEngine.Debug.Log(GameData.SaveFileNames);

        }

        public void LoadScene()
        {
            SceneManager.LoadScene(SceneToLoad);
        }

        public void CreateNewGame()
        {
            if(string.IsNullOrEmpty(NewGameInputField.text))
            {
                return;
            }

            GameManager.Instance.SetActiveSave(NewGameInputField.text);
            LoadScene();
        }
    }

    [Serializable]
    class GameDataList
    {
        public List<string> SaveFileNames = new List<string>();
        
    }
}