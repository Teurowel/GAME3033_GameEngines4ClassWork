using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Menus
{

    public class MainMenuWidget : MenuWidget
    {
        [SerializeField] string StartMenuName = "Load Game Menu";
        [SerializeField] string OptionsMenuName = "Options Menu";

        public void OpenStartMenu()
        {
            MenuController.EnableMenu(StartMenuName);
        }

        public void OpenOptionsMenu()
        {
            MenuController.EnableMenu(OptionsMenuName);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }

}