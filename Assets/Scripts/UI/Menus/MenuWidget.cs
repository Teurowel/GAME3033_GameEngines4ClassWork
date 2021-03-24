using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI.Menus
{
    public abstract class MenuWidget : MonoBehaviour
    {
        [SerializeField] private string MenuName;
        protected MenuController MenuController;

        private void Awake()
        {
            MenuController = FindObjectOfType<MenuController>();
            if (MenuController)
            {
                MenuController.AddMenu(MenuName, this);
            }
            else
            {
                Debug.LogError("Menu Controller not found!");
            }

            //Enable mouse cursor
            AppEvents.Invoke_OnMouseCursorEnable(true);
        }

        public void ReturnToRootMenu()
        {
            if(MenuController)
            {
                MenuController.ReturnToRootMenu();
            }
        }

        public void EnableWidget()
        {
            gameObject.SetActive(true);
        }

        public void DisableWidget()
        {
            gameObject.SetActive(false);
        }
    }

}