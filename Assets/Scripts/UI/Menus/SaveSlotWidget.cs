using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI.Menus
{
    public class SaveSlotWidget : MonoBehaviour
    {
        private string SaveName;

        private GameManager Manager;
        private LoadGameWidget LoadWidget;

        [SerializeField] private TMP_Text SaveNameText;

        private void Awake()
        {
            Manager = GameManager.Instance;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize(LoadGameWidget parentWidget, string saveName)
        {
            LoadWidget = parentWidget;
            SaveName = saveName;
            SaveNameText.text = saveName;
        }

        public void SelectSave()
        {
            Manager.SetActiveSave(SaveName);
            LoadWidget.LoadScene();
        }
    }

}